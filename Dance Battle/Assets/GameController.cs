using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.VersionControl;
using UnityEditor.Animations;

public class GameController : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public AnimatorController Orange;
    public AnimatorController blue;
    // Use this for initialization
    void Awake () {
        
        if (PlayerPrefs.GetString("Player1").Equals("Orange"))
        {
            player1.GetComponent<Animator>().runtimeAnimatorController = Orange as RuntimeAnimatorController;
        }
        else if (PlayerPrefs.GetString("Player1").Equals("Blue"))
        {
            player1.GetComponent<Animator>().runtimeAnimatorController = blue as RuntimeAnimatorController;
        }
        if (PlayerPrefs.GetString("Player2").Equals("Orange"))
        {
            player2.GetComponent<Animator>().runtimeAnimatorController = Orange as RuntimeAnimatorController;
        }
        else if (PlayerPrefs.GetString("Player2").Equals("Blue"))
        {
            print("I am here father");
            player2.GetComponent<Animator>().runtimeAnimatorController = blue as RuntimeAnimatorController;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
