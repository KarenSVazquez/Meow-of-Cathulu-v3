using System.Collections;
using UnityEngine;
using TMPro; // reference al texto

public class Dialogue : MonoBehaviour
{
    // Update is called once per frame
    //estas propiedades? o parametros, aparecen en la pestaña del Script Dailogue en el npc
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel; // ref al panel para activar y desactivar
    [SerializeField] private TMP_Text dialogueText; // ref al texto
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines; // SerializeField param agrego dialogoLines + TextArea 4 lines min, 6max
    // Declaramos variables
    private float typingTime = 0.05f; //segundos
    private bool isPlayerinRange;
    private bool didDialogueStart; // si estamos dialogando esta var es true
    private int line; // que linea mostramos 
    void Update()
    {
        if (isPlayerinRange && Input.GetButtonDown("Fire1"))
        {
           if (!didDialogueStart)
            {
                StartDialogue();
            }
           else if (dialogueText.text == dialogueLines[line])
            {
                NextDialogueLine();
            }
        }
    }

    private void NextDialogueLine()
    {
        line++;
        if(line < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
        }

    }
    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true); // arranca la charla
        dialogueMark.SetActive(false); // se va el sprint
        line = 0;
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine() // corruptina funcion que permite pausar la ejecucion y retomar, like temporizador
    {
        dialogueText.text = string.Empty; // el text inicia vacio
        foreach(char ch in dialogueLines[line]) // recorremos las lineas
        {
            dialogueText.text += ch; // concatenando caracteres
            yield return new WaitForSeconds(typingTime); // WaitForSeconds(typingTime) = tiempo que esperamos, aprox 20 caracteres x seg
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerinRange = true;
            dialogueMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerinRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
