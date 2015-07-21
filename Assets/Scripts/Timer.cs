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
	}

	void Update () 
	{
		time += Time.deltaTime;
		score.text = time.ToString ("0.00");
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
