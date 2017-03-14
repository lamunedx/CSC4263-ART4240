using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour {

	Animator anim;
	Collision2D coll = null;
	Rigidbody2D rigidBody = null;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		punch ();
		kick ();
		moveRight ();
		moveLeft ();
		crouch ();
	}

	void punch(){
		if (Input.GetKey (KeyCode.A)) 
		{
			anim.SetBool ("punch",true);
		} 
		else 
		{
			anim.SetBool ("punch",false);
		}
	}
		

	void moveRight(){
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.Translate (Vector2.right * 2 * Time.deltaTime);
			anim.SetBool ("walk",true);

		} 
		else 
		{
			anim.SetBool ("walk",false);
		}
	}

	void moveLeft(){
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.Translate (Vector2.left * 2 * Time.deltaTime);
			anim.SetBool ("walk",true);
		} 
		else 
		{
			anim.SetBool ("walk",false);
		}
	}


	void crouch(){
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			anim.SetBool ("crouch",true);
		} 
		else 
		{
			anim.SetBool ("crouch",false);
		}
	}

	void kick(){
		if (Input.GetKey (KeyCode.S)) 
		{
			anim.SetBool ("kick",true);
		} 
		else 
		{
			anim.SetBool ("kick",false);
		}
	}

	void OnCollisionEnter (Collision2D coll){
		if (coll.gameObject.name == "ground" && Input.GetKey (KeyCode.UpArrow))
		{
			rigidBody.AddForce (Vector2.up * 5 * Time.deltaTime);
			anim.SetBool ("jump", true);
		} 
		else 
		{
			anim.SetBool ("jump",false);
		}
	}

}

