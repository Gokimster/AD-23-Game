using UnityEngine;
using System.Collections;

public class ProgressionController : MonoBehaviour {
	
	float time;
	int stage;
	int maxStage = 7;
	int[] stageTimes;
	float[] speedStages;

	void Start () 
	{
		stage = 0;
		InitStageTimes();
		InitSpeedStages();
	}

	void Update () 
	{
		time = GameObject.Find("Timer").GetComponent<Timer>().GetTime();

		if ((time > stageTimes[stage]) && (stage < maxStage))
			NextStage();
	}

	void InitStageTimes ()
	{
		stageTimes = new int[] {5,10,15,20,25,30,40,50};
	}

	void InitSpeedStages ()
	{
		speedStages = new float[] {4,4,3,3,2,2,1};
	}

	void NextStage ()
	{
		GameObject.Find("Character").GetComponent<PlayerController>().IncreaseSpeed(speedStages[stage]);
		stage++;
	}

	public int getStage ()
	{
		return stage;
	}
}
