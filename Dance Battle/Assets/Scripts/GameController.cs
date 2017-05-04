using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public RuntimeAnimatorController Orange;
    public RuntimeAnimatorController blue;
    // Use this for initialization
    void Awake () {
        
        if (PlayerPrefs.GetString("Player1").Equals("Orange"))
        {
            player1.GetComponent<Animator>().runtimeAnimatorController = Orange;
        }
        else if (PlayerPrefs.GetString("Player1").Equals("Blue"))
        {
            player1.GetComponent<Animator>().runtimeAnimatorController = blue;
        }
        if (PlayerPrefs.GetString("Player2").Equals("Orange"))
        {
            player2.GetComponent<Animator>().runtimeAnimatorController = Orange;
        }
        else if (PlayerPrefs.GetString("Player2").Equals("Blue"))
        {
            print("I am here father");
            player2.GetComponent<Animator>().runtimeAnimatorController = blue;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
