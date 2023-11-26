using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCatnipsNeeded : MonoBehaviour
{
    public int requiredCatnip = 0;
    public bool _satisfied = false;
    public SpriteRenderer catnipImage;
    public Sprite happyFaceSprite;
    public Sprite sadFaceSprite;
    public float destroyDelay = 1.0f;
    public SO_CatCounting catCounting;
    public Sprite[] dialogueImages;
    public bool canInteract = false;
    public int canvasIndex;

    private bool catnipSubtracted = false;

    void Awake()
    {
        if (catCounting != null)
        {
            catCounting.InitializeCanvasObjectIndices();
            catCounting.FindCanvasObjects(); // A�adido para encontrar autom�ticamente objetos del canvas
        }
        else
        {
            Debug.LogError("catCounting no est� asignado en " + gameObject.name);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        catnipImage.sprite = sadFaceSprite;
        canInteract = true;

        if (!catnipSubtracted && other.tag == "Player")
        {
            Debug.Log("Player entered NPC area");
            HandleInteraction();
        }
        else
        {
            Debug.Log("Sad face set");
            catnipImage.sprite = sadFaceSprite;
            catnipImage.enabled = false;
            canInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player exited NPC area");
        catnipImage.sprite = null;
        canInteract = false;
    }

    void DesactivarImagenesNPCSouls()
    {
        if (catCounting.canvasObjectIndices.Length > 0)
        {
            // Obtener el �ndice del �ltimo elemento del array
            int lastIndex = catCounting.canvasObjectIndices.Length - 1;

            // Obtener el �ndice del objeto del canvas actual
            int canvasIndex = catCounting.canvasObjectIndices[lastIndex];

            if (canvasIndex >= 0 && canvasIndex < catCounting.canvasObjects.Length)
            {
                GameObject canvasObject = catCounting.canvasObjects[canvasIndex];

                Image imageComponent = canvasObject.GetComponent<Image>();
                if (imageComponent != null) imageComponent.enabled = false;

                MeshRenderer meshRendererComponent = canvasObject.GetComponent<MeshRenderer>();
                if (meshRendererComponent != null) meshRendererComponent.enabled = false;

                canvasObject.SetActive(false);

                // Eliminar el �ltimo �ndice del array
                List<int> remainingIndices = new List<int>(catCounting.canvasObjectIndices);
                remainingIndices.RemoveAt(lastIndex);
                catCounting.canvasObjectIndices = remainingIndices.ToArray();
            }
            else
            {
                Debug.LogError(" i est� fuera del rango del array de canvasObjects.");
            }
        }
        else
        {
            Debug.LogError("No hay m�s objetos del canvas o el �ndice del NPC no est�.");
        }
    }


    void DestroyNPC()
    {
        catCounting.CatNumber += 1;

        int length = Mathf.Min(dialogueImages.Length, catCounting.dialogueImages.Length);

        for (int i = 0; i < length; i++)
        {
            catCounting.dialogueImages[i] = dialogueImages[i];
        }

        catCounting.IsCathuluVisible = true;
        catCounting.NPCPosition = transform.position;
        Destroy(gameObject);
    }

    private void Update()
    {
        HandleInteraction();
    }

    private void HandleInteraction()
    {
        CatnipCounter catnipCounterScript = GameObject.FindWithTag("CatnipCounter").GetComponent<CatnipCounter>();

        if (canInteract && Input.GetButtonDown("Activate") && !catnipSubtracted)
        {
            if (catnipCounterScript != null && catnipCounterScript.HasEnoughCatnips(requiredCatnip) && _satisfied == false)
            {
                catnipSubtracted = true;
                catnipCounterScript.SubtractCatnips(requiredCatnip);
                requiredCatnip = 0;
                _satisfied = true;

                catnipImage.sprite = happyFaceSprite;

                StartCoroutine(DelayedInteraction());
                catCounting.CheckVictoryCondition();
            }
            else
            {
                catnipImage.sprite = sadFaceSprite;
            }
        }
    }

    IEnumerator DelayedInteraction()
    {
        yield return new WaitForSeconds(0.5f);
        DestroyNPC();
        DesactivarImagenesNPCSouls();
    }
}
