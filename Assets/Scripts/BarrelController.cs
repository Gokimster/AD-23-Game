using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour
{
	int BARREL_NO = 5;
	int barrelType;
	// Use this for initialization
	void Start () {
		barrelType = Random.Range (1, BARREL_NO);
		gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Art/rock"+barrelType.ToString());
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

