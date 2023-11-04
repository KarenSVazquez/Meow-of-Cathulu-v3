using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_cathulu : MonoBehaviour
{
    public SpriteRenderer dialogue;
    public Sprite[] dialogueImg;
    public bool firstTime;
    private int currentIndex;
    private float imageDisplayInterval = 1.0f; // 1 segundo
    private float timer = 0.0f;
    // Start is called before the first frame update


    void Start()
    {
        firstTime = false;
        currentIndex = 0;

    }
    // Update is called once per frame
    void Update()
    {
        //A = A + Time.deltatime mientras esto sea true se sigue sumando
        // cuando A sea >= 
        //for activar dialogo
        // 2for trasnciocion de tiempo, cuando tiene el primer dialogo trasniciont dialogo true, ahora cuanta A = A + Time.deltatime
        // cuando A sea mayor igual q 1 es false para q no vuelva a contar, luego se incrementa el indice de los dialogos
        // luego A queda en cero ,bool de conteo a cero
        // yield return new WaitForSeconds(typingTime);
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                // Aquí puedes mostrar la siguiente imagen del diálogo
                if (currentIndex < dialogueImg.Length - 1)
                {
                    Debug.Log("entra for?");
                    currentIndex++;
                    dialogue.sprite = dialogueImg[currentIndex];
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (firstTime == false)
            {
                currentIndex = 0;
                dialogue.sprite = dialogueImg[currentIndex];
                firstTime = true;

            }
            else
            {
                timer = imageDisplayInterval;
                /*
                   if (currentIndex < dialogueImg.Length - 1)
                       Debug.Log("entra for?");
                   {
                       currentIndex++;

                   }
                   dialogue.sprite = dialogueImg[currentIndex];
                */
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogue.sprite = null;
        }
    }
}
 
