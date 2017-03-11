using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		action ();
	}

	void action(){
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			anim.SetBool ("walk",true);
		} 
		else 
		{
			anim.SetBool ("walk",false);
		}

		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			anim.SetBool ("jump",true);
		} 
		else 
		{
			anim.SetBool ("jump",false);
		}

		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			anim.SetBool ("crouch",true);
		} 
		else 
		{
			anim.SetBool ("crouch",false);
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			anim.SetBool ("punch",true);
		} 
		else 
		{
			anim.SetBool ("punch",false);
		}

		if (Input.GetKey (KeyCode.S)) 
		{
			anim.SetBool ("kick",true);
		} 
		else 
		{
			anim.SetBool ("kick",false);
		}

	}
}
