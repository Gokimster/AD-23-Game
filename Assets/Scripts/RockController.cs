using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {
	
	int ROCK_NO = 5;
	int rockType;
	public PolygonCollider2D[] colliders;
	// Use this for initialization
	void Start () {
		rockType = Random.Range (1, ROCK_NO);
		gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Art/rock"+rockType.ToString());
		colliders [rockType-1].enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
