using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	//for moving
	float move;
	public float speed = 10f;
	//public bool facingRight = true;
	Animator anim;
	
	//for jumping
	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 15f;
	
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
		//anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//DebugLines();
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//SetGrounded ();
		//anim.SetBool ("ground", grounded);
		//anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
		Jump ();
		//CheckFrontColission ();
		//anim.SetFloat ("speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
		
	}
	/*
	void SetGrounded()
	{
		if(Physics2D.Linecast (bRBegin.position, bREnd.position, whatIsGround))
		{
			grounded = true;
		}else
		{
			if(Physics2D.Linecast (bLBegin.position, bLEnd.position, whatIsGround))
			{
				grounded = true;
			}else
			{
				grounded = false;
			}
		}
		
	}*/
	/*
	void DebugLines()
	{
		Debug.DrawLine(lTBegin.position, lTEnd.position, Color.green);
		Debug.DrawLine(lBBegin.position, lBEnd.position, Color.magenta);
		Debug.DrawLine(rTBegin.position, rTEnd.position, Color.red);
		Debug.DrawLine(rBBegin.position, rBEnd.position, Color.red);
		Debug.DrawLine(bRBegin.position, bREnd.position, Color.red);
		Debug.DrawLine(bLBegin.position, bLEnd.position, Color.red);
		
	}*/
	
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
		
