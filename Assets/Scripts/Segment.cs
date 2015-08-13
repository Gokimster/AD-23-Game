using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Segment : MonoBehaviour
{
	enum objectTypes {Obstacle, PowerUp};
	float length;
	int partsNo;
	float partPopulateProbability;
	bool readyToPopulate;
	//flame barrel
	Dictionary <string, object> drone;
	Dictionary <string, object> rock;
	Dictionary <string, object> barrel;
	Dictionary <string, object> flameBarrel;
	float maxSpawnProbability;
	//ground
	public GameObject ground;

	// Use this for initialization
	void Start ()
	{
		InitObjects ();
		SpawnObject (ground, transform.position.x);
	}

	void InitObjects ()
	{
		maxSpawnProbability = 0;
		//ground
		ground = Resources.Load("ground") as GameObject;
		//objects
		flameBarrel = new Dictionary<string, object> ();
		flameBarrel. Add ("gameObject", Resources.Load("flameBarrel") as GameObject);
		flameBarrel.Add ("type", (int) objectTypes.PowerUp);
		flameBarrel.Add ("spawnProbability", 0.07f);
		maxSpawnProbability += (float) flameBarrel["spawnProbability"];
		drone = new Dictionary<string, object> ();
		drone.Add ("gameObject", Resources.Load("drone") as GameObject);
		drone.Add ("type", (int) objectTypes.Obstacle);
		drone.Add ("spawnProbability", 0.31f);
		maxSpawnProbability += (float) drone["spawnProbability"];
		rock = new Dictionary<string, object> ();
		rock.Add ("gameObject", Resources.Load("rock") as GameObject);
		rock.Add ("type", (int) objectTypes.Obstacle);
		rock.Add ("spawnProbability", 0.31f);
		maxSpawnProbability += (float) rock["spawnProbability"];
		barrel = new Dictionary<string, object> ();
		barrel.Add ("gameObject", Resources.Load ("barrel") as GameObject);
		barrel.Add ("type", (int) objectTypes.Obstacle);
		barrel.Add ("spawnProbability", 0.31f);
		maxSpawnProbability += (float) barrel["spawnProbability"];
	}

	void SpawnObstacles ()
	{
		for (int i = 0; i < partsNo; i++) {
			if (Random.Range(0, 1) >= partPopulateProbability)
			{
				GameObject temp = new GameObject();
				float rand = Random.Range(0,maxSpawnProbability);
				float currProb = (float) flameBarrel["spawnProbability"];
				if(rand <= currProb){
					temp = Instantiate((GameObject)flameBarrel["gameObject"]);
				}else{
					currProb += (float) drone["spawnProbability"];
					if(rand <= currProb){
						temp = Instantiate((GameObject)drone["gameObject"]);
					}else{
						currProb += (float) rock["spawnProbability"];
						if(rand <= currProb){
							temp = Instantiate((GameObject)rock["gameObject"]);
						}else{
							currProb += (float) (float) barrel["spawnProbability"];
							if(rand <= currProb){
								temp = Instantiate((GameObject)barrel["gameObject"]);
							}
						}
					}
				}
				float xPos = transform.position.x - (length/2) + (length/partsNo) * i + ((length/partsNo)/2);
				temp.transform.position = new Vector3(xPos, temp.transform.position.y, temp.transform.position.z);
			}

		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (readyToPopulate) {
			SpawnObstacles();
			readyToPopulate = false;
		}
	}
	public void SetProgression (float partPopulateProbability, int partsNo)
	{
		this.partsNo = partsNo;
		this.partPopulateProbability = partPopulateProbability;
		readyToPopulate = true;
	}
	public void SetDimensions(float length, float x)
	{
		this.length = length;
		transform.position = new Vector3(x, 0, 0);
	}

	public void SpawnObject(GameObject obj, float x)
	{
		GameObject s = Instantiate (obj);
		s.transform.parent = transform;
		s.transform.position = new Vector3 (x, 0, 0);
	}
}

