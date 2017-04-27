﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountdownTimer : MonoBehaviour {

    // Use this for initialization
    public int timeLeft = 5;
    public Text countdownText;
    public GameObject matchTime;
    public GameObject player1;
    public GameObject player2;
    private int textSize;
    private bool reSize;
	private bool pl = false;
    AudioSource song;

    // Use this for initialization
    void Start()
    {
        
        song = GetComponent<AudioSource>();
        StartCoroutine("LoseTime");
        textSize = countdownText.fontSize;
        reSize = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft>= 0)
        {
            countdownText.fontSize--;
            countdownText.text = "" + timeLeft;
            if (reSize)
            {
                countdownText.fontSize = textSize;
                reSize = false;
            }
			if (timeLeft == 1 && pl == false)
            {
				pl = true;
                song.Play();
            }
            if (timeLeft == 0)
            {
                countdownText.text = "FIGHT";
                matchTime.GetComponent<fightTime>().enabled = true;
                player1.GetComponent<Player1Control>().enabled = true;
                player2.GetComponent<Player2Control>().enabled = true;
                
            }
        }
        else if(timeLeft < 0)
        {
            countdownText.text = "";
            StopCoroutine("LoseTime");
            this.GetComponent<CountdownTimer>().enabled = false;
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            reSize = true;
            
        }
    }
}
