using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float		timer = 5f;
	private float		elapsed = 0f;
	public GameObject	panel_top;
	public GameObject	panel_bottom;
	private Vector2 	ntop;
	private Vector2 	nbottom;
	private int			width = 60;

	public GameObject	final_plane;
	public GameObject	plane;
	public GameObject	venti_right;
	public GameObject	venti_left;
	public Sprite		venti_right_down;
	public Sprite		plane_broken;

	private bool		goal = false;
	private float		init_x;

	// Use this for initialization
	void Start () {
		ntop = panel_top.GetComponent<RectTransform> ().offsetMax;
		nbottom = panel_bottom.GetComponent<RectTransform> ().offsetMax;
		init_x = plane.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (!goal) {
			if (elapsed < timer) {
				elapsed += Time.deltaTime;
				// manage timers
				print (ntop.y);
				ntop.y = (2*width / width) * (elapsed/timer); 
				nbottom.y = nbottom.y - (elapsed * timer / width);

				panel_top.GetComponent<RectTransform> ().offsetMax = ntop;
				panel_bottom.GetComponent<RectTransform> ().offsetMax = nbottom;

				// manage plane
				float x_pos = init_x + (final_plane.transform.position.x - init_x) * elapsed / timer;
				plane.GetComponent<RectTransform>().transform.position = new Vector2(x_pos, plane.transform.position.y);

				// push button ?
				RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.zero);
				if(hit.collider != null)
				{
					goal = true;
					venti_right.GetComponent<Image>().sprite = venti_right_down;
				}
			} else {
				// fin du game
				plane.GetComponent<Image>().sprite = plane_broken;
				venti_left.GetComponent<ParticleSystem>().Stop();
				print ("Game Over");
				// Load next level
			}
		} else {
			print ("Success");
		}
	}
}
