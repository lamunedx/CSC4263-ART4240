using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fightTime : MonoBehaviour
{
    private int timeLeft;
    public Text timer;
    public Text fightover;
    public Canvas endCanvas;
    public Image p1;
    public Image p2;
    public Image tie;
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
                if (player1.GetComponent<Player1Control>().playerHealth > player2.GetComponent<Player2Control>().playerHealth)
                {
                    endCanvas.enabled = true;
                    p1.enabled = true;
                }
                else if (player1.GetComponent<Player1Control>().playerHealth < player2.GetComponent<Player2Control>().playerHealth)
                {
                    endCanvas.enabled = true;
                    p2.enabled = true;
                }
                else
                {
                    endCanvas.enabled = true;
                    tie.enabled = true;
                }
                timer.text = "";
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
