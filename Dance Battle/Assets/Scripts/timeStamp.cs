using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeStamp : MonoBehaviour {
    private int timeLeft;
    public Text text;

	// Use this for initialization
	void Start () {
        timeLeft = 90;
        text.text = "" + timeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator updateTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            GetComponentInChildren<Text>().text = "" + timeLeft;
        }
    }
}
