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

    // Datos específicos del NPC
    public string npcName;
    public int catnipsNeeded;

    // Variable para realizar el seguimiento de si ya se restó una vez
    private bool catnipSubtracted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
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

    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player exited NPC area");
        catnipImage.sprite = null;
        canInteract = false;

    }




    void DesactivarImagenesNPCSouls()
    {
        // componente NPCData
        NPCData npcData = GetComponent<NPCData>();

        if (npcData != null)
        {
            // objeto del canvas asociado al NPC actual
            GameObject canvasObject = npcData.canvasObject;

            if (canvasObject != null)
            {
                // Desactivar  Image (si existe)
                Image imageComponent = canvasObject.GetComponent<Image>();

                if (imageComponent != null)
                {
                    imageComponent.enabled = false;
                }

                // Desactivar  MeshRenderer (si existe)
                MeshRenderer meshRendererComponent = canvasObject.GetComponent<MeshRenderer>();

                if (meshRendererComponent != null)
                {
                    meshRendererComponent.enabled = false;
                }

                // Desactivar el objeto 
                canvasObject.SetActive(false);
            }
            else
            {
                Debug.LogError(" 'canvasObject' en NPCData es null.");
            }
        }
        else
        {
            Debug.LogError(" NPCData no está en NPC.");
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
        catCounting.NPCPosition = transform.position; // guarda la posición del NPC
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

                // Mostrar el happy face
                catnipImage.sprite = happyFaceSprite;

                // Esperar antes de ejecutar el resto del código
                StartCoroutine(DelayedInteraction());
            }
            else
            {
                // muestra el sad face si no hay suficientes catnips
                catnipImage.sprite = sadFaceSprite;
            }
        }
    }

    IEnumerator DelayedInteraction()
    {
        // Esperar 0.5 segundos antes 
        yield return new WaitForSeconds(0.5f);

        // Ejecutar el resto del código después de esperar
        DestroyNPC();
        DesactivarImagenesNPCSouls();
    }



}
