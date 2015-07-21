using UnityEngine;
using System.Collections;

public class ProgressionController : MonoBehaviour {
	
	float time;
	int stage;
	int maxStage = 6;
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
		time = GameObject.Find("Timer").GetComponent<Timer>().getTime();

		if ((time > stageTimes[stage]) && (stage < maxStage))
			NextStage();
	}

	void InitStageTimes ()
	{
		stageTimes = new int[] {20,30,40,50,60,70,80};
	}

	void InitSpeedStages ()
	{
		speedStages = new float[] {5,4,3,2,2,1};
	}

	void NextStage ()
	{
		GameObject.Find("Player").GetComponent<PlayerController>().IncreaseSpeed(speedStages[stage]);
		stage++;
	}

	public int getStage ()
	{
		return stage;
	}
}
