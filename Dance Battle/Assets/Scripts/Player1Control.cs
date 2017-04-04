using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player 1's control script
public class Player1Control : MonoBehaviour {

  private Animator animator;
  private Rigidbody2D body;
  private bool Crouched;
  private bool OnGround;

	void Start () {
    animator = GetComponent<Animator>();
    body = GetComponent<Rigidbody2D>();
    Crouched = false;
    OnGround = true;
	}

  void Update() {
    // movement keys -----------------------------------------------------------
    if(Input.GetKey(KeyCode.UpArrow) && OnGround) {
      body.AddForce(Vector2.up * 300f);
      animator.Play("JumpingUp");
      OnGround = false;
    }
	if (!OnGround) {
		if (body.velocity.y < 1 && body.velocity.y >= 0) {
			animator.Play ("Jumping");
		} 
		else if (body.velocity.y > 1) {
			animator.Play ("JumpHang");
		} 
		else {
			animator.Play ("JumpingDown");
		}
	}
    //else if(!OnGround && body.velocity.y != 0) {
    //  animator.Play("Jumping");
    //}
    //else if(!OnGround && body.velocity.y == 0) {
    //  animator.Play("JumpHang");
    //}
    //else if(Input.GetKey(KeyCode.UpArrow) && OnGround) {
    //  animator.Play("JumpingDown");
    //  animator.Play("Idle");
    //}
	if (Input.GetKey(KeyCode.DownArrow) && !Crouched && OnGround) {
      animator.Play("CrouchingDown");
      Crouched = true;
    }
    else if(Input.GetKey(KeyCode.DownArrow) && Crouched && OnGround) {
      animator.Play("Crouching");
    }
    else if (Input.GetKeyUp(KeyCode.DownArrow) && Crouched && OnGround) {
      animator.Play("CrouchingUp");
	  Crouched = false;
    }
	if (!Crouched && OnGround) {
		animator.Play ("Idle");
	}
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if(collision.gameObject.name == "Platform") {
      OnGround = true;
    }
  }
}
