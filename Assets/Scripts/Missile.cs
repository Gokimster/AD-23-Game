using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
{
	float speed;
	// Use this for initialization
	void Start ()
	{
		speed = 10f;
		Physics2D.IgnoreLayerCollision(12,11,true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2 (-speed, 0);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}

