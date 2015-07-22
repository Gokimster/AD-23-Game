using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	float time;
	public bool isTiming;
	float highScore;
	Text score;

	void Start () 
	{
		time = 0;
		highScore = PlayerPrefs.GetFloat("highScore");
		score = GetComponent<Text> ();
		isTiming = true;
	}

	void Update () 
	{
		if (isTiming) {
			time += Time.deltaTime;
			score.text = time.ToString ("0.00");
		}
	}

	void OnEnd ()
	{
		isTiming = false;
		if(time > highScore)
			PlayerPrefs.SetFloat("highScore", time);

	}

	public float GetTime ()
	{
		return time;
	}

	public void EndTimer ()
	{
		OnEnd ();
	}

	void PauseTimer (bool pause)
	{
		isTiming = pause;
	}
}
