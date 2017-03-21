using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player 2's control script
public class Player2Control : MonoBehaviour {

  private Animator anime;
  private Rigidbody2D rigid;
	private CapsuleCollider2D[] Coll;
	private bool inAir;
	private bool isCrouching;

  // reference to the other player
  public GameObject otherPlayer;
  private Rigidbody2D otherRigid;

  void Start() {
    anime = GetComponent<Animator>();
    rigid = GetComponent<Rigidbody2D>();
		Coll = GetComponents<CapsuleCollider2D> ();

    otherRigid = otherPlayer.GetComponent<Rigidbody2D>();
  }

  void Update() {
		if (Input.GetKey(KeyCode.D) && isCrouching == false) {
      transform.Translate(Vector2.right * 2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    if (Input.GetKeyUp(KeyCode.D)) {
      anime.SetBool("Speed", false);
    }

		if (Input.GetKey(KeyCode.A) && isCrouching == false) {
      transform.Translate(Vector2.left * 2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    if (Input.GetKeyUp(KeyCode.A)) {
      anime.SetBool("Speed", false);
    }

		if (Input.GetKeyDown(KeyCode.W) && isCrouching == false && inAir == false) {
      rigid.AddForce(new Vector2(0, 550f));
    }

    // make sure the player is facing the right direction
    if (rigid.position.x > otherRigid.position.x) {
      rigid.transform.localScale = new Vector2(1f, rigid.transform.localScale.y);
      otherRigid.transform.localScale = new Vector2(-1f, otherRigid.transform.localScale.y);
    }
    else {
      rigid.transform.localScale = new Vector2(-1f, rigid.transform.localScale.y);
      otherRigid.transform.localScale = new Vector2(1f, otherRigid.transform.localScale.y);
    }

		if (Input.GetKey(KeyCode.S) && inAir == false) {
			Coll [0].enabled = false;
			Coll [1].enabled = true;
			transform.position = new Vector2 (transform.localPosition.x,-3.24f);
			anime.SetBool("Crouch", true);
			isCrouching = true;

		}
		if (Input.GetKeyUp(KeyCode.S)) {
			Coll [1].enabled = false;
			Coll [0].enabled = true;
			transform.position = new Vector2 (transform.localPosition.x,-2.96f);
			anime.SetBool("Crouch", false);
			isCrouching = false;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && inAir == false && isCrouching == false) {
			rigid.AddForce(Vector2.up * 550f);
		}
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.name == "Platform") {
      anime.SetBool("Ground", true);
      anime.SetBool("Jump", false);
			inAir = false;
    }
  }

  private void OnCollisionExit2D(Collision2D collision) {
    if (collision.gameObject.name == "Platform") {
      anime.SetBool("Ground", false);
      anime.SetBool("Jump", true);
			inAir = true;
    }
  }
}
