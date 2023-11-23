// Script NPCCatnipsNeeded
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


    // Variable para realizar el seguimiento de si ya se restó una vez
    private bool catnipSubtracted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        {
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
                    DesactivarImagenesNPCSouls();
                    Debug.Log("Después ");


                    catnipSubtracted = true;
                }
                else
                {

                    catnipImage.sprite = sadFaceSprite;
                }
            }
        }
    }
    void DesactivarImagenesNPCSouls()
    {
        GameObject[] npcSouls = GameObject.FindGameObjectsWithTag("npcSouls");

        foreach (GameObject npcSoul in npcSouls)
        {
            // Desactivar el componente Image (si existe)
            Image imageComponent = npcSoul.GetComponent<Image>();

            if (imageComponent != null)
            {
                imageComponent.enabled = false;
            }

            // Desactivar el componente MeshRenderer (si existe)
            MeshRenderer meshRendererComponent = npcSoul.GetComponent<MeshRenderer>();

            if (meshRendererComponent != null)
            {
                meshRendererComponent.enabled = false;
            }

            // Desactivar el objeto completo
            npcSoul.SetActive(false);
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

    /*
   

    void DestroyNPC()
    {
        catCounting.CatNumber += 1; // cada vez que se destuya suma 1 
        for (int i = 0; i < dialogueImages.Length; i++)
        {
            catCounting.dialogueImages[i] = dialogueImages[i];
        }
        catCounting.IsCathuluVisible = true;
        catCounting.NPCPosition = this.gameObject.transform.position; // guarda la posicoon del npc
        Destroy(gameObject);
    }
     */
}
