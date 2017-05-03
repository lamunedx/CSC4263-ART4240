using System.Collections;
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
    public GameObject ready;
    public GameObject set;
    public GameObject go;
    private bool pl = false;
    AudioSource song;

    // Use this for initialization
    void Start()
    {
        
        song = GetComponent<AudioSource>();
        StartCoroutine("LoseTime");

    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft>= 0)
        {
            countdownText.fontSize--;
            countdownText.text = "" + timeLeft;
            if(timeLeft == 2)
            {
                ready.SetActive(true);
                ready.transform.localScale = new Vector3(ready.transform.localScale.x - .01f, ready.transform.localScale.y - .01f, ready.transform.localScale.z - .01f);

            }
            else if(timeLeft == 1)
            {
                {
                    ready.SetActive(false);
                    set.SetActive(true);
                    set.transform.localScale = new Vector3(set.transform.localScale.x - .01f, set.transform.localScale.y - .01f, set.transform.localScale.z - .01f);

                }
            }
            else if (timeLeft == 0)
            {
                {
                    set.SetActive(false);
                    go.SetActive(true);
                    go.transform.localScale = new Vector3(go.transform.localScale.x - .01f, go.transform.localScale.y - .01f, go.transform.localScale.z - .01f);

                }
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
            go.SetActive(false);
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
            
        }
    }
}
