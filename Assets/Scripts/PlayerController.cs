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
	public bool isRolling;

	//colliders
	[SerializeField]
	private BoxCollider2D[] colliders;
	private int currentColliderIndex;
	
	// Use this for initialization
	void Start () 
	{
		speed = 10f;
		jumpForce = 600f;
		anim = GetComponent<Animator> ();
		SetJumping ();
		isRolling = false;
		currentColliderIndex = 0;
		SetCollider (currentColliderIndex);
	}
	
	// Update is called once per frame
	void Update () 
	{
		DebugLines();
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		SetGrounded ();
		SetJumping ();
		//anim.SetBool ("ground", grounded);
		//anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
		Jump ();
		Roll ();

		//CheckFrontColission ();
		//anim.SetFloat ("speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
		
	}
	void SetGrounded()
	{
		LayerMask lMask = 1 << LayerMask.NameToLayer ("Ground");
		RaycastHit2D hit = Physics2D.Raycast (transform.position + new Vector3(0, -(transform.lossyScale.y), 0), Vector2.down, .5f, lMask);
		if (hit.collider != null && hit.collider.tag.Equals ("Ground"))
		{
			grounded = true;
		} else 
		{
			grounded = false;
		}
		
	}

	void SetJumping ()
	{
		anim.SetBool("isJumping", false);
		anim.SetBool ("isFalling", false);
		if (transform.GetComponent<Rigidbody2D> ().velocity.y > 0) {
			anim.SetBool("isJumping", true);
		}
		if (transform.GetComponent<Rigidbody2D> ().velocity.y < 0) {
			anim.SetBool ("isFalling", true);
		}
	}

	void DebugLines()
	{
		Debug.DrawRay (transform.position + new Vector3(0, -(transform.lossyScale.y/1.8f), 0), Vector2.down, Color.blue);
		Debug.Log (transform.GetComponent<Rigidbody2D> ().velocity.y.ToString());
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

	void Roll ()
	{
		isRolling = false;
		anim.SetBool ("isRolling", false);
		if(grounded && Input.GetKey (KeyCode.S))
		{
			isRolling = true;
			anim.SetBool("isRolling", true);
		}
	}

	public void SetCollider(int number)
	{
		colliders [currentColliderIndex].enabled = false;
		currentColliderIndex = number;
		colliders [currentColliderIndex].enabled = true;
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
		
