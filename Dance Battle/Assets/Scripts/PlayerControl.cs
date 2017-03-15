using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script file will allow users to control their character movement
public class PlayerControl : MonoBehaviour {

  Animator animate;
	
	void Start () {
    animate = GetComponent<Animator>();
	}
	
	
	void Update () {
    KeyInput();
    {
      float move = Input.GetAxis("Horizontal");
      animate.SetFloat("Speed", move);
    }

	}

  void KeyInput() {
    if(Input.GetKey(KeyCode.RightArrow)) {
      transform.Translate(Vector2.right * 3f * Time.deltaTime);
      transform.eulerAngles = new Vector2(0, 0);
    }

    if (Input.GetKey(KeyCode.LeftArrow)) {
      transform.Translate(Vector2.right * -3f * Time.deltaTime);
      transform.eulerAngles = new Vector2(0, 0);
    }
  }
}
