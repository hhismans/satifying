using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class active : MonoBehaviour {

	// Use this for initialization
	public bool isOpen = false;
	private bool isMoving = false;
	private int step = Screen.width / 50;
	public float inTime = 0.1f;
	public GameObject elemLeft;
	public GameObject elemRight;
	public Button myButton;
	private int deplacement = Screen.width / 2;
	private IEnumerator routine;
	private IEnumerator routinee;

	public void open()
	{
		if (!isOpen && !isMoving)
		{
			Debug.Log("button pushed");
			routine = slide(deplacement, step);
			StartCoroutine(routine);
		}
	}
	public void close()
	{
		if (isOpen && !isMoving)
		{
			Debug.Log("button pushed");
			routinee = slide(deplacement, -step);
			StartCoroutine(routinee);
		}
	}

	IEnumerator slide(int pix, int step)
	{
		isMoving = true;
		float waitTime = (float)pix / (float)step;
		waitTime = inTime / waitTime;
		Debug.Log("pix = " + pix + "step = " + step + "waitTime = " + waitTime);
		for (int i = 0; i < pix; i += Mathf.Abs(step))
		{
			elemLeft.gameObject.transform.Translate(-step,0,0);
			elemRight.gameObject.transform.Translate(step,0,0);
			yield return new WaitForSeconds(waitTime);
		}
		if (!isOpen)
			isOpen = true;
		else
			isOpen = false;
		isMoving = false;
	}
}
