using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
	private uint goodThings;
	private uint badThings;

	private bool print = true;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (print) {
			Debug.Log ("Good " + goodThings.ToString ());
			Debug.Log ("Bad " + badThings.ToString ());
			print = false;
		}
	}

	public void incrementGood()
	{
		goodThings++;
		print = true;
	}

	public void incrementBad()
	{
		badThings++;
		print = true;
	}
}
