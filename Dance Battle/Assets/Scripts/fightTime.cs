using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fightTime : MonoBehaviour
{
    private int timeLeft;
    public Text timer;
    public Text fightover;
    public GameObject player1;
    public GameObject player2;

    // Use this for initialization
    void Start()
    {
        timeLeft = 90;
        timer.text = "" + timeLeft;
        StartCoroutine(updateTime());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator updateTime()
    {
        bool greaterThanZero = true;
        while (greaterThanZero)
        {
            if (timeLeft <= 0)
            {
                fightover.text = "FIGHT OVER";
                greaterThanZero = false;
                player1.GetComponent<Player1Control>().enabled = false;
                player2.GetComponent<Player2Control>().enabled = false;
            }
            else
            {
                yield return new WaitForSeconds(1);
                timeLeft--;
                GetComponentInChildren<Text>().text = "" + timeLeft;
            }
        }
    }
    
}
