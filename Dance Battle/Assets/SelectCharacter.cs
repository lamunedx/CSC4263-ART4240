using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour {
    public GameObject selectP1;
    public GameObject selectP2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(selectP1.transform.position.x == -1.623 || selectP2.transform.position.x == -1.623)
        {
            if(Input.GetAxis("LeftJoystickX1") > .5  || Input.GetKeyDown(KeyCode.D))
            {
                selectP1.transform.Translate(new Vector3(1.603f, 0f));
            }
            if(Input.GetAxis("LeftJoystickX") > .5 || Input.GetKeyDown(KeyCode.RightArrow))
            {
                selectP2.transform.Translate(new Vector3(1.603f, 0f));
            }
        }
	}
}
