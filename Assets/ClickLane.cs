using UnityEngine;
using System.Collections;

public class ClickLane : MonoBehaviour {

	private bool laneSelected;
	public KeyCode selectKey;

	// Use this for initialization
	void Start () 
	{}
	
	// Update is called once per frame
	void Update () 
	{
		selectThisLane ();
	}
		
	bool selectThisLane()
	{
		if(Input.GetKeyDown(selectKey))
		{
			laneSelected = true;
			return true;
		}
			
		laneSelected = false;
		return false;
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if(laneSelected)
		{
			Destroy (collider.gameObject);
		}
	}
}
