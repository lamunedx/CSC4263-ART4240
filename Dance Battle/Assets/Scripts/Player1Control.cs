﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player 1's control script
public class Player1Control : MonoBehaviour {

  private Animator anime;
  private Rigidbody2D rigid;
	private CapsuleCollider2D[] cap;

  // reference to the other player
  public GameObject otherPlayer;
  private Rigidbody2D otherRigid;

  void Start() {
    anime = GetComponent<Animator>();
    rigid = GetComponent<Rigidbody2D>();
		cap = GetComponents<CapsuleCollider2D>();

    otherRigid = otherPlayer.GetComponent<Rigidbody2D>();
  }

  void Update() {
    // movement keys -----------------------------------------------------------
		if (Input.GetKey(KeyCode.D) && !anime.GetBool("Crouch")) {
      transform.Translate(Vector2.right * 2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    if (Input.GetKeyUp(KeyCode.D)) {
      anime.SetBool("Speed", false);
    }

		if (Input.GetKey(KeyCode.A) && !anime.GetBool("Crouch")) {
      transform.Translate(Vector2.left * 2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    if (Input.GetKeyUp(KeyCode.A)) {
      anime.SetBool("Speed", false);
    }

    if (Input.GetKey(KeyCode.S) && anime.GetBool("Ground")) {
      cap[0].enabled = false;
      cap[1].enabled = true;
      //GetComponentInChildren<EdgeCollider2D>().enabled = false;
      transform.position = new Vector2(transform.localPosition.x, -3.24f);
      anime.SetBool("Crouch", true);
    }
    if (Input.GetKeyUp(KeyCode.S)) {
      cap[1].enabled = false;
      cap[0].enabled = true;
      //GetComponentInChildren<EdgeCollider2D>().enabled = true;
      transform.position = new Vector2(transform.localPosition.x, -2.96f);
      anime.SetBool("Crouch", false);
    }

    if (Input.GetKeyDown(KeyCode.W) && anime.GetBool("Ground")) {
			rigid.AddForce(Vector2.up * 550f);
		}

    // action keys -------------------------------------------------------------
    if (Input.GetKeyDown(KeyCode.Z)) {
      anime.SetBool("Punch", true);
      cap[2].enabled = true;
      cap[2].isTrigger = true;
    }
    if (anime.GetCurrentAnimatorStateInfo(0).IsName("Punch")) {
      anime.SetBool("Punch", false);
      cap[2].enabled = false;
    }

    // make sure the player is facing the right direction
    // note: this handles both players, so don't add this to the player 1 script
    if (rigid.position.x > otherRigid.position.x) {
      rigid.transform.localScale = new Vector2(1f, rigid.transform.localScale.y);
      otherRigid.transform.localScale = new Vector2(-1f, otherRigid.transform.localScale.y);
    }
    else {
      rigid.transform.localScale = new Vector2(-1f, rigid.transform.localScale.y);
      otherRigid.transform.localScale = new Vector2(1f, otherRigid.transform.localScale.y);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.name == "Platform") {
      anime.SetBool("Ground", true);
      anime.SetBool("Jump", false);
    }
  }

  private void OnCollisionExit2D(Collision2D collision) {
    if (collision.gameObject.name == "Platform") {
      anime.SetBool("Ground", false);
      anime.SetBool("Jump", true);
    }
  }
}
