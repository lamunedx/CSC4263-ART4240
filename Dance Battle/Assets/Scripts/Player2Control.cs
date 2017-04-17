using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player 2's control script
public class Player2Control : MonoBehaviour {

  private Animator anime;
  private Rigidbody2D rigid;
  private CapsuleCollider2D[] cap;

	void Start () {
    anime = GetComponent<Animator>();
    rigid = GetComponent<Rigidbody2D>();
    cap = GetComponents<CapsuleCollider2D>();
	}

	void Update () {
    // movement keys -----------------------------------------------------------
    if (Input.GetKey(KeyCode.RightArrow) && !anime.GetBool("crouching")) {
      transform.Translate(Vector2.right * 2f * Time.deltaTime);
      anime.SetBool("moving", true);
    }
    if (Input.GetKeyUp(KeyCode.RightArrow)) {
      anime.SetBool("moving", false);
    }

	  if (Input.GetKey(KeyCode.LeftArrow) && !anime.GetBool("crouching")) {
      transform.Translate(Vector2.left * 2f * Time.deltaTime);
      anime.SetBool("moving", true);
    }
    if (Input.GetKeyUp(KeyCode.LeftArrow)) {
      anime.SetBool("moving", false);
    }

	  if (Input.GetKey(KeyCode.DownArrow) && anime.GetBool("onGround")) {
      //cap[0].enabled = false;
      //cap[1].enabled = true;
      //GetComponentInChildren<EdgeCollider2D>().enabled = false;
      //transform.position = new Vector2(transform.localPosition.x, -3.24f);
	    anime.SetBool("crouching", true);
    }
    if (Input.GetKeyUp(KeyCode.DownArrow)) {
      cap[1].enabled = false;
      cap[0].enabled = true;
      //GetComponentInChildren<EdgeCollider2D>().enabled = true;
      transform.position = new Vector2(transform.localPosition.x, -2.96f);
	    anime.SetBool("crouching", false);
    }

	  if (Input.GetKeyDown(KeyCode.UpArrow) && anime.GetBool("onGround")) {
      rigid.AddForce(Vector2.up * 550f);
    }

    // action keys -------------------------------------------------------------
	  if (Input.GetKeyDown(KeyCode.I) && !anime.GetBool("moving")) {
      anime.SetBool("punching", true);
      //cap[2].enabled = true;
      //cap[2].isTrigger = true;
    }
	  if (anime.GetCurrentAnimatorStateInfo(0).IsName("punch")) {
      anime.SetBool("punching", false);
      //cap[2].enabled = false;
    }
	  if (Input.GetKeyDown(KeyCode.O) && !anime.GetBool("moving")) {
	    anime.SetBool("kicking", true);
	  }
	  if (anime.GetCurrentAnimatorStateInfo(0).IsName("kick")) {
	    anime.SetBool("kicking", false);
	  }
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.name == "Platform") {
	  anime.SetBool("onGround", true);
      anime.SetBool("jumping", false);
    }
    if (collision.gameObject.name == "Player2") {
      anime.SetBool("jumping", false);
    }
  }

  private void OnCollisionExit2D(Collision2D collision) {
    if (collision.gameObject.name == "Platform") {
	  anime.SetBool("onGround", false);
      anime.SetBool("jumping", true);
    }
  }
}
