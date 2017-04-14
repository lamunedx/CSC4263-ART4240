using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargets : MonoBehaviour {
    float spawnTime;
	// Use this for initialization
	void Awake () {
        spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time-spawnTime >= 2.0f)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.position += new Vector3(0.075f, 0f, 0f);
        }
	}
}
