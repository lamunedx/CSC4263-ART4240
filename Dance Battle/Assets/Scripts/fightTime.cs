using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fightTime : MonoBehaviour
{
    private int timeLeft;
    public Text text;

    // Use this for initialization
    void Start()
    {
        timeLeft = 90;
        text.text = "" + timeLeft;
        StartCoroutine(updateTime());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator updateTime()
    {
        while (true)
        {
            if (timeLeft < 0)
            {
                StopCoroutine(updateTime());
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
