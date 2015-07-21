using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	//for moving
	float move;
	public float speed;
	//public bool facingRight = true;
	Animator anim;
	
	//for jumping
	public bool grounded = false;
	public float jumpForce;
	
	//for Collision Raycasting
	//behind
	//public Transform lTBegin,lTEnd;
	//public Transform lBBegin,lBEnd;
	//front
	//public Transform rTBegin,rTEnd;
	//public Transform rBBegin, rBEnd;
	//down
	//public Transform bRBegin, bREnd;
	//public Transform bLBegin, bLEnd;
	//public bool isColliding;
	
	// Use this for initialization
	void Start () 
	{
		speed = 10f;
		jumpForce = 300f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		DebugLines();
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		SetGrounded ();
		//anim.SetBool ("ground", grounded);
		//anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
		Jump ();
		//CheckFrontColission ();
		//anim.SetFloat ("speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
		
	}
	void SetGrounded()
	{
		RaycastHit2D hit = Physics2D.Raycast (transform.position + new Vector3(0, -(transform.lossyScale.y/1.8f), 0), Vector2.down, .5f);
		if (hit.collider != null && hit.collider.tag.Equals ("Ground"))
		{
			grounded = true;
		} else 
		{
			grounded = false;
		}
		
	}

	void DebugLines()
	{
		Debug.DrawRay (transform.position + new Vector3(0, -(transform.lossyScale.y/1.8f), 0), Vector2.down, Color.blue);
	}
	
	//jump action 
	void Jump ()
	{
		if (grounded && Input.GetKeyDown (KeyCode.W)) 
		{
			//anim.SetBool ("ground", false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}
		
	}

	void Crouch ()
	{
		if(grounded && Input.GetKeyDown (KeyCode.S))
		{

		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.tag == "Obstacle")
		{
			//end game
		}
	}

	public void IncreaseSpeed (float inc){
		speed += inc;
	}

	//check front colission for being stuck in air
	/*
	void CheckFrontColission () {
		
		if(Physics2D.Linecast (rTBegin.position, rTEnd.position, 1 << LayerMask.NameToLayer("Ground")))
		{
			isColliding = true;
		}else
		{
			if(Physics2D.Linecast (rBBegin.position, rBEnd.position, 1 << LayerMask.NameToLayer("Ground")))
			{
				isColliding = true;
			}else
			{
				isColliding = false;
			}
		}
		/*if(hit.transform.name.Contains("MovingPlatform"))
			{
				Transform movingPlatform  = hit.collider.transform;
				
				
			}
		
		if (isColliding && !grounded) 
		{
			move = 0;
		}
		
	}*/
	
}
		
