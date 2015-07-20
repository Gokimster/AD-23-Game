using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	float time;
	public bool isTiming;
	float highScore;

	void Start () 
	{
		time = 0;
		highScore = PlayerPrefs.GetFloat("highScore");
	}

	void Update () 
	{
		time += Time.deltaTime;
	}

	void OnEnd ()
	{
		if(time > highScore)
			PlayerPrefs.SetFloat("highScore", time);
	}

	public float getTime ()
	{
		return time;
	}
}
