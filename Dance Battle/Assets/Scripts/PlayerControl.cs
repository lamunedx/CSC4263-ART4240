using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

  private Animator anime;
  private Rigidbody2D rigid;

  private bool grounded;

	void Start () {
    anime = GetComponent<Animator>();
    rigid = GetComponent<Rigidbody2D>();
    rigid.freezeRotation = true;

    grounded = false;
	}
	
	void Update () {
    if (Input.GetKey(KeyCode.RightArrow)) {
      transform.Translate(Vector2.right * 2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    else if (Input.GetKeyUp(KeyCode.RightArrow)) {
      anime.SetBool("Speed", false);
    }

    if (Input.GetKey(KeyCode.LeftArrow)) {
      transform.Translate(Vector2.right * -2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    else if (Input.GetKeyUp(KeyCode.LeftArrow)) {
      anime.SetBool("Speed", false);
    }

    if (Input.GetKeyDown(KeyCode.Space) && grounded) {
      anime.SetBool("Jump", true);
      rigid.AddForce(new Vector2(0, 500f));
      grounded = false;
      print("player jumped");
      print(grounded);
    }
    else if (grounded) {
      anime.SetBool("Jump", false);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.name == "Platform") {
      grounded = true;
      print("player has landed");
      print(grounded);
    }
  }
}
