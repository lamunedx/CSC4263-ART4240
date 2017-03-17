using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour {

  private Animator anime;
  private Rigidbody2D rigid;

  void Start() {
    anime = GetComponent<Animator>();
    rigid = GetComponent<Rigidbody2D>();
    rigid.freezeRotation = true;
  }

  void Update() {
    if (Input.GetKey(KeyCode.D)) {
      transform.Translate(Vector2.right * 2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    if (Input.GetKeyUp(KeyCode.D)) {
      anime.SetBool("Speed", false);
    }

    if (Input.GetKey(KeyCode.A)) {
      transform.Translate(Vector2.right * -2f * Time.deltaTime);
      anime.SetBool("Speed", true);
    }
    if (Input.GetKeyUp(KeyCode.A)) {
      anime.SetBool("Speed", false);
    }

    if (Input.GetKeyDown(KeyCode.W) && anime.GetBool("Ground")) {
      rigid.AddForce(new Vector2(0, 550f));
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
