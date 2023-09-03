using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;

    public float livingTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, livingTime);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = direction.normalized * speed * Time.deltaTime;

        //transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
        transform.Translate(movement);

    }


}
