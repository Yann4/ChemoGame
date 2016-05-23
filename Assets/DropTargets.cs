using UnityEngine;
using System.Collections;

public class DropTargets : MonoBehaviour 
{
	public float leftLaneXPos;
	public float middleLaneXPos;
	public float rightLaneXPos;

	public float topOfLane;

	private enum TargetType{ARROW,};

	private double lastDrop;
	public double dropRate = 1.0;

	private GameObject arrow;

	// Use this for initialization
	void Start ()
	{
		lastDrop = Time.time;

		arrow = Resources.Load ("Target") as GameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time - lastDrop > dropRate)
		{
			DropInLane (arrow, Random.Range (0, 3));
		}
	}

	//lane int, 0 - left, 1 - middle, 2 - right. Any other value defaults to right
	void DropInLane(GameObject target, int lane)
	{
		Vector3 pos = new Vector3 (0.0f, topOfLane, 0.0f);

		if (lane == 0) 
		{
			pos.x = leftLaneXPos;
		}else if(lane == 1)
		{
			pos.x = middleLaneXPos;
		}else
		{
			pos.x = rightLaneXPos;
		}

		Instantiate (target, pos, Quaternion.identity);
		lastDrop = Time.time;
	}
}
