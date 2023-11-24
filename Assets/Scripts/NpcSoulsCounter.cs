using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
  
    public GameObject currentNPC;

    void ObtenerNPC()
    {
        DesactivarImagenesNPCSouls();
    }

    void DesactivarImagenesNPCSouls()
    {
        GameObject[] npcSouls = GameObject.FindGameObjectsWithTag("npcSouls");

        foreach (GameObject npcSoul in npcSouls)
        {
          
            SpriteRenderer spriteRenderer = npcSoul.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }
            else
            {
                
            }
        }
    }
}
