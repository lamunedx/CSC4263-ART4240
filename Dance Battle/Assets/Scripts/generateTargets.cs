using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class generateTargets : MonoBehaviour {
    public GameObject circle;
    private float[] waitTime;
    AudioSource song;
    // Use this for initialization
    void Start () {
        string[] lines = File.ReadAllLines(@"C:\Users\Mahdi\Documents\GitHub\CSC4263-ART4240\Dance Battle\Assets\brainPowerTimes.txt");
        waitTime = new float[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            double x = Convert.ToDouble(lines[i]);
            waitTime[i] = (float)x;
        }
        StartCoroutine(spawnCircles());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator spawnCircles()
    {
        bool songTimeOut = false;
        while (!songTimeOut)
        {
            if (Time.time >= 120)
            {
                songTimeOut = true;
            }
            else
            {
                yield return new WaitForSeconds(.6521739130434f);
                Instantiate(circle, new Vector3(-9f, 1f, 0), Quaternion.identity);
            }
        }
    }
}
