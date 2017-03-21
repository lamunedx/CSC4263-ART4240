using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player 1's control script
public class Player1Control : MonoBehaviour {

  private Animator anime;
  private Rigidbody2D rigid;

	void Start () {
    anime = GetComponent<Animator>();
    rigid = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
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
      anime.SetBool("Crouch", true);
    }
    if (Input.GetKeyUp(KeyCode.DownArrow)) {
      anime.SetBool("Crouch", false);
    }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anime.SetBool("myPunch", true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            anime.SetBool("myPunch", false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            anime.SetBool("myKick", true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            anime.SetBool("myKick", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && anime.GetBool("Ground")) {
      rigid.AddForce(Vector2.up * 550f);
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
