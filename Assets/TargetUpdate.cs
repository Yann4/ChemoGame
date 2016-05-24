using UnityEngine;
using System.Collections;

public class TargetUpdate : MonoBehaviour 
{
	private float speed = 0.1f;
	public bool good = true;
	private GameObject background;

	// Use this for initialization
	void Start ()
	{
		background = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = transform.position;

		pos.y -= speed;

		transform.position = pos;
	}

	public void clicked()
	{
		Score score = background.GetComponent<Score> ();

		if(good)
		{
			score.incrementGood ();
		}else{
			score.incrementBad ();
		}
	}

	void OnBecameInvisible()
	{
		Destroy (this.gameObject);
	}
}
