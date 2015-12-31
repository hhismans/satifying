using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MoveSquare : MonoBehaviour {

	public Text			StartText;
	public GameObject	final;
	private bool		canMove = true;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (canMove) {
			Color n = StartText.GetComponent<Text> ().color;
			n.a = 1 - (Mathf.Abs (final.transform.position.y - this.transform.position.y) / 300f);
			StartText.GetComponent<Text> ().color = n;

			if (Input.mousePosition.y >= final.transform.position.y) {
				this.transform.position = new Vector2 (this.transform.position.x, final.transform.position.y);
				print ("GG!!!!!!!!!!!!!!!!!!!");
				canMove = false;
				StartCoroutine (startMovement ());
			} else {
				this.transform.position = new Vector2 (this.transform.position.x, Input.mousePosition.y);
			}
		}
	}

	IEnumerator startMovement()
	{
		for (int i = 0; i <= 100f; i++) {
			StartText.transform.Translate (0f, -0.5f, 0f);
			yield return new WaitForSeconds (0.01f);
		}
		// LOAD LEVEL
	}
}
