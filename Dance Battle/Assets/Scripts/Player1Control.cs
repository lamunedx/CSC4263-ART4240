using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player 1's control script
public class Player1Control : MonoBehaviour {

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
    if (Input.GetKey(KeyCode.RightArrow) && !anime.GetBool("Crouch")) {
      transform.Translate(Vector2.right * 2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    if (Input.GetKeyUp(KeyCode.RightArrow)) {
      anime.SetBool("Speed", false);
    }

    if (Input.GetKey(KeyCode.LeftArrow) && !anime.GetBool("Crouch")) {
      transform.Translate(Vector2.left * 2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    if (Input.GetKeyUp(KeyCode.LeftArrow)) {
      anime.SetBool("Speed", false);
    }

    if (Input.GetKey(KeyCode.DownArrow)) {
      cap[0].enabled = false;
      cap[1].enabled = true;
      transform.position = new Vector2(transform.localPosition.x, -3.24f);
      anime.SetBool("Crouch", true);
    }
    if (Input.GetKeyUp(KeyCode.DownArrow)) {
      cap[1].enabled = false;
      cap[0].enabled = true;
      transform.position = new Vector2(transform.localPosition.x, -2.96f);
      anime.SetBool("Crouch", false);
    }

    if (Input.GetKeyDown(KeyCode.UpArrow) && anime.GetBool("Ground")) {
      rigid.AddForce(Vector2.up * 550f);
    }

    // action keys -------------------------------------------------------------
    if (Input.GetKeyDown(KeyCode.Alpha9)) {
      anime.SetBool("Punch", true);
      cap[2].enabled = true;
      //if (cap[2].OverlapPoint(new Vector2(...))) {

      //}
    }
    if (anime.GetCurrentAnimatorStateInfo(0).IsName("Punch")) {
      anime.SetBool("Punch", false);
      cap[2].enabled = false;
    }
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.name == "Platform") {
      anime.SetBool("Ground", true);
      anime.SetBool("Jump", false);
    }
    if (collision.gameObject.name == "Player2") {
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
