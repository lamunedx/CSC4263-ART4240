using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player 1's control script
public class Player1Control : PlayerHealth{

  private Animator anime;
  private Rigidbody2D rigid;
	private CapsuleCollider2D[] Coll;
	private CircleCollider2D cColl;
	private bool inAir;
	private bool isCrouching;

	void Start () {
    anime = GetComponent<Animator>();
    rigid = GetComponent<Rigidbody2D>();
		Coll = GetComponents<CapsuleCollider2D> ();
		cColl = GetComponent<CircleCollider2D> ();
		base.damage = 5f;
	}
	
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.RightArrow) && isCrouching == false) {
      transform.Translate(Vector2.right * 2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    if (Input.GetKeyUp(KeyCode.RightArrow)) {
      anime.SetBool("Speed", false);
    }

		if (Input.GetKey(KeyCode.LeftArrow) && isCrouching == false) {
      transform.Translate(Vector2.left * 2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    if (Input.GetKeyUp(KeyCode.LeftArrow)) {
      anime.SetBool("Speed", false);
    }

		if (Input.GetKey(KeyCode.DownArrow) && inAir == false) {
			Coll [0].enabled = false;
			Coll [1].enabled = true;
			transform.position = new Vector2 (transform.localPosition.x,-3.24f);
      anime.SetBool("Crouch", true);
			isCrouching = true;

    }
    if (Input.GetKeyUp(KeyCode.DownArrow)) {
			Coll [1].enabled = false;
			Coll [0].enabled = true;
			transform.position = new Vector2 (transform.localPosition.x,-2.96f);
			anime.SetBool("Crouch", false);
			isCrouching = false;
    }

		if (Input.GetKeyDown(KeyCode.UpArrow) && inAir == false && isCrouching == false) {
      rigid.AddForce(Vector2.up * 550f);
    }

		if(Input.GetKey(KeyCode.B)){
			cColl.enabled = true;
			anime.SetBool ("Punch",true);
		}

		if(Input.GetKeyUp(KeyCode.B)){
			cColl.enabled = false;
			anime.SetBool ("Punch",false);
		}

  }

  private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Platform") {
			anime.SetBool ("Ground", true);
			anime.SetBool ("Jump", false);
			inAir = false;
		}
    if (collision.gameObject.name == "Player2") {
      anime.SetBool("Jump", false);
    }
  }

  private void OnCollisionExit2D(Collision2D collision) {
    if (collision.gameObject.name == "Platform") {
      anime.SetBool("Ground", false);
      anime.SetBool("Jump", true);
			inAir = true;
    }
  }

	//detect punching
	private void OnTriggerEnter2D(Collider2D colli){
		if(colli.gameObject.transform.name.Equals("player2"))
		{
			this.decreaseHealth();
		}
	}
}
