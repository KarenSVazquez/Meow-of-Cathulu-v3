using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCatnipsNeeded : MonoBehaviour
{
    public int requiredCatnip = 0;
    public int catnipCounter;
    public Text catnipCounterCanvas;
    public BoxCollider2D theBC;
    public SpriteRenderer catnipImage;
    public Sprite happyFaceSprite;
    public Sprite sadFaceSprite;
    public float destroyDelay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        theBC = GetComponent<BoxCollider2D>();
        catnipCounterCanvas = GameObject.FindWithTag("CatnipCounterCanvas").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        catnipCounter = GameObject.FindWithTag("CatnipCounter").GetComponent<CatnipCounter>().catnipCount;
        catnipCounterCanvas.text = catnipCounter.ToString();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && (catnipCounter >= requiredCatnip))
        {
            catnipCounter = catnipCounter - requiredCatnip;
            Debug.Log("catnipCounter" + catnipCounter);
            catnipImage.sprite = happyFaceSprite;
            Invoke("DestroyNPC", destroyDelay);
        }
        else
        {
            catnipImage.sprite = sadFaceSprite;
        }
    }

    void DestroyNPC()
    {
        Destroy(gameObject);
    }
}
