using UnityEngine;
using System.Collections;

public class Segment : MonoBehaviour
{
	//flame barrel
	public GameObject flameBarrel;
	//drone
	public GameObject drone;
	//rock
	public GameObject rock;
	//ground
	public GameObject ground;

	// Use this for initialization
	void Start ()
	{
		flameBarrel = Resources.Load("flameBarrel") as GameObject;
		drone = Resources.Load("drone") as GameObject;
		rock = Resources.Load("rock") as GameObject;
		ground = Resources.Load("ground") as GameObject;
		SpawnObject (ground);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SetXPosition(float x)
	{
		transform.position = new Vector3(x, 0, 0);
	}

	public void SpawnObject(GameObject obj)
	{
		GameObject s = Instantiate (obj);
		s.transform.parent = transform;
		s.transform.position = new Vector3 (transform.position.x, 0, 0);
	}
}

