using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
	// Awake is good to get references from the same object or others in the scene
	private void Awake()
	{
		Debug.Log("I'm attached as a component of an object in the Scene!");
	}

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("You have just pressed PLAY BUTTON!");
	}

	// Update is called once per frame
	void Update()
	{
		/* Let's check some
		 * input from keyboard
		 * and change colors! */
		if (Input.GetKeyDown(KeyCode.R)) {
			this.GetComponent<SpriteRenderer>().color = Color.red;
		}

		if (Input.GetKeyDown(KeyCode.Y)) {
			this.GetComponent<SpriteRenderer>().color = Color.yellow;
		}

		if (Input.GetKeyDown(KeyCode.C)) {
			this.GetComponent<SpriteRenderer>().color = Color.cyan;
		}

		if (Input.GetKeyDown(KeyCode.G)) {
			this.GetComponent<SpriteRenderer>().color = Color.green;
		}

		if (Input.GetKeyDown(KeyCode.B))
		{
			this.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		if (Input.GetKeyDown(KeyCode.W))
		{
			this.GetComponent<SpriteRenderer>().color = Color.white;
		}


	}
	




}
