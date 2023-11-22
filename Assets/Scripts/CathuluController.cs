// CathuluController
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CathuluController : MonoBehaviour
{
    public SO_CatCounting catCounting;
    public GameObject CathuluPrefab;
    public Sprite[] dialogueImages;
    private SpriteRenderer cathuluSpriteRenderer;
    public float imageTime = 1.0f;
    // cada que se cumpla la condicion de num de pcn - aparece cathulu
    // Start is called before the first frame update
    void Awake()
    {
        // for recorrer el 
        cathuluSpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        cathuluSpriteRenderer = GetComponent<SpriteRenderer>();
        if (catCounting.IsCathuluVisible == true)
        {
            // aparece cathulu + muestra img luego termina en false

            GameObject cathuluInstance = Instantiate(CathuluPrefab, catCounting.NPCPosition, Quaternion.identity);
            catCounting.IsCathuluVisible = false;
            StartCoroutine(DestroyCathuluAfterDelay(cathuluInstance, 5f));
        }
        Debug.Log("Longitud de catCounting.dialogueImages: " + catCounting.dialogueImages.Length);
    }
    IEnumerator DestroyCathuluAfterDelay(GameObject cathuluInstance, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Destruye cathuluInstance después del tiempo de espera
        Destroy(cathuluInstance);
    }
    // los npc van a tener las img que se guardan desde el obj counteing cat y este guarda las img que va a estar con cahtulu


}
