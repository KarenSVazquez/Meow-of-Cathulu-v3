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

    // Datos espec�ficos del NPC
    public string npcName;
    public int catnipsNeeded;

    // Variable para realizar el seguimiento de si ya se rest� una vez
    private bool catnipSubtracted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        catnipImage.sprite = sadFaceSprite;
        canInteract = true;

        if (!catnipSubtracted && other.tag == "Player")
        {
            CatnipCounter catnipCounterScript = GameObject.FindWithTag("CatnipCounter").GetComponent<CatnipCounter>();

            if (catnipCounterScript != null && catnipCounterScript.HasEnoughCatnips(requiredCatnip) && _satisfied == false)
            {
                catnipCounterScript.SubtractCatnips(requiredCatnip);
                requiredCatnip = 0;
                _satisfied = true;

                catnipImage.sprite = happyFaceSprite;
                Invoke("DestroyNPC", destroyDelay);
                Debug.Log("Antes ");

                // Accede a los datos espec?ficos del NPC directamente aqu?
                Debug.Log("Nombre del NPC: " + npcName);
                Debug.Log("Catnips necesarios: " + catnipsNeeded);

                DesactivarImagenesNPCSouls();
                Debug.Log("Despu?s ");

                catnipSubtracted = true;

            }
            else
            {
                catnipImage.sprite = sadFaceSprite;
                canInteract = true;
            }
        }
    }
        void OnTriggerExit2D(Collider2D other)
    {
        catnipImage.sprite = null;
        canInteract = false;

    }




    void DesactivarImagenesNPCSouls()
    {
        // Obt�n la referencia al componente NPCData
        NPCData npcData = GetComponent<NPCData>();

        if (npcData != null)
        {
            // Obt�n la referencia al objeto del canvas asociado al NPC actual
            GameObject canvasObject = npcData.canvasObject;

            if (canvasObject != null)
            {
                // Desactivar el componente Image (si existe)
                Image imageComponent = canvasObject.GetComponent<Image>();

                if (imageComponent != null)
                {
                    imageComponent.enabled = false;
                }

                // Desactivar el componente MeshRenderer (si existe)
                MeshRenderer meshRendererComponent = canvasObject.GetComponent<MeshRenderer>();

                if (meshRendererComponent != null)
                {
                    meshRendererComponent.enabled = false;
                }

                // Desactivar el objeto completo
                canvasObject.SetActive(false);
            }
            else
            {
                Debug.LogError("campo 'canvasObject' en NPCData es null.");
            }
        }
        else
        {
            Debug.LogError("componente NPCData no est� en NPC.");
        }
    }



    void DestroyNPC()
    {
        catCounting.CatNumber += 1; // cada vez que se destruye, suma 1 

        int length = Mathf.Min(dialogueImages.Length, catCounting.dialogueImages.Length);

        for (int i = 0; i < length; i++)
        {
            catCounting.dialogueImages[i] = dialogueImages[i];
        }

        catCounting.IsCathuluVisible = true;
        catCounting.NPCPosition = transform.position; // guarda la posici�n del NPC
        Destroy(gameObject);
    }

    private void Update()
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
                Invoke("DestroyNPC", destroyDelay);

            }
        }
    }
}
