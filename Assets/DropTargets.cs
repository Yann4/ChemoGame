using UnityEngine;
using System.Collections;

public class DropTargets : MonoBehaviour 
{
	//Spatial data
	public GameObject leftLane, rightLane, middleLane;
	private float llXPos;
	private float mlXPos;
	private float rlXPos;

	private float topOfLane = 5.0f;

	//"Difficulty" values
	private double lastDrop;
	//Values in seconds
	public double slowestDropRate = 1.0; //Longest time possible to go without drop
	public double fastestDropRate = 0.2; //Shortest time possible to have 2 drops happen consecutively
	public uint chanceToDrop = 50; //As percentage, chance for a drop to happen after $fastestDropRate time has elapsed

	private enum TargetType{ARROW_GOOD, ARROW_BAD};
	private GameObject arrowGood, arrowBad;

	// Use this for initialization
	void Start ()
	{
		//Cap to 100%
		if(chanceToDrop > 100)
		{
			chanceToDrop = 100;
		}

		llXPos = leftLane.transform.position.x;
		mlXPos = middleLane.transform.position.x;
		rlXPos = rightLane.transform.position.x;

		lastDrop = Time.time;

		loadDrops ();
	}

	void loadDrops()
	{
		arrowGood = Resources.Load ("Target") as GameObject;
		arrowBad = Resources.Load ("ArrowUp") as GameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		if(shouldDrop())
		{
			DropInLane (getTargetToDrop(), selectLane());
		}
	}

	bool shouldDrop()
	{
		double currentTime = Time.time;
		double timeSinceLastDrop = currentTime - lastDrop;

		if(timeSinceLastDrop > fastestDropRate)
		{
			if(Random.Range(0, 100) < chanceToDrop)
			{
				return true;
			}
		}

		if(timeSinceLastDrop > slowestDropRate)
		{
			return true;
		}

		return false;
	}

	//Todo: add logic to make it fun
	GameObject getTargetToDrop()
	{
		if(Random.Range(0, 100) > 50)
		{
			return arrowBad;
		}

		return arrowGood;
	}

	//Todo: add logic to make it fun
	int selectLane()
	{
		return Random.Range (0, 3);
	}

	//lane int, 0 - left, 1 - middle, 2 - right. Any other value defaults to right
	void DropInLane(GameObject target, int lane)
	{
		Vector3 pos = new Vector3 (0.0f, topOfLane, 0.0f);

		if (lane == 0) 
		{
			pos.x = llXPos;
		}else if(lane == 1)
		{
			pos.x = mlXPos;
		}else
		{
			pos.x = rlXPos;
		}

		Instantiate (target, pos, Quaternion.identity);
		lastDrop = Time.time;
	}
}
