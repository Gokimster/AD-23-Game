using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{

	//Segment [] segments;
	ArrayList segments;
	//constants
	float SEGMENT_LENGTH;
	int TUT_SEGMENT_COUNT;

	GameObject segment;
	GameObject tutorial;
	// Use this for initialization
	void Start ()
	{
		segments = new ArrayList();
		segment = Resources.Load("Segment") as GameObject;
		tutorial = Resources.Load("Tutorial") as GameObject;
		SEGMENT_LENGTH = 19.2f;
		TUT_SEGMENT_COUNT = 4;
		InitTutorial ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameObject.Find ("Character").transform.position.x > ((GameObject)segments [1]).transform.position.x)
			AddSegment (((GameObject)segments[segments.Count-1]).transform.position.x + SEGMENT_LENGTH, true);
	}

	void InitTutorial ()
	{
		for (int i = 0; i < TUT_SEGMENT_COUNT; i++) {
			AddSegment (0 + i * SEGMENT_LENGTH, false);
		}
		GameObject seg = Instantiate (tutorial);
		tutorial.transform.SetParent(transform);
		tutorial.transform.position = new Vector3 (SEGMENT_LENGTH, tutorial.transform.position.y, tutorial.transform.position.z);
	}

	void AddSegment(float x, bool remove)
	{
		if (remove) {
			Destroy (((GameObject)segments [0]));
			segments.RemoveAt (0);
		}
		GameObject seg = Instantiate (segment);
		seg.GetComponent<Segment>().SetXPosition (x);
		seg.transform.parent = transform;
		segments.Add (seg);
	}

}

