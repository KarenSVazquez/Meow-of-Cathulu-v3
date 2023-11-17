using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.1f;
    public float minY, minX;
    public float maxY, maxX;
    public float waitingTime;
    private GameObject _target;


    private Vector3 _initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        minY = _initialPosition.y;
        minX = _initialPosition.x;
        maxY = _initialPosition.y + maxY;
        maxX = _initialPosition.x + maxX;

        UpdateTarget();
        StartCoroutine("Floating");
    }

    // Update is called once per frame


    void UpdateTarget()
    {

        if (_target == null)
        {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(maxX, minY);


            return;
        }

        if (_target.transform.position.y == minY)
        {
            _target.transform.position = new Vector2(minX, maxY);

        }
        else if (_target.transform.position.y == maxY)
        {
            _target.transform.position = new Vector2(maxX, minY);

        }
    }
    IEnumerator Floating()
    {



        while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
        {


            //Moving to the Target
            Vector2 direction = _target.transform.position - transform.position;
            float yDirection = direction.y;
            transform.Translate(direction.normalized * speed * Time.deltaTime);

            yield return null;


        }

        UpdateTarget();
        yield return new WaitForSeconds(waitingTime);


        StartCoroutine("Floating");






    }

    void OnDestroy()
    {

        Destroy(_target);


    }
}
