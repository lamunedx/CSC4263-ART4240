﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MusicGenerator : MonoBehaviour {
    AudioSource song;

    public float[] samples = new float[512];
    public float[] frequencyRange = new float[8];
    public List<float> timeStampsOfBeats = new List<float>();
    Boolean checkWrite = false;
    
    // Use this for initialization
    void Start() {
        song = GetComponent<AudioSource>();
        //StartCoroutine(spawnCircles());

    }

    // Update is called once per frame
    void Update() {
        getSpectrumAudioSource();
        getfrequencyrange();
        if(frequencyRange[0] > 50)
        {
            timeStampsOfBeats.Add(song.time);
        }
        if(Time.time > song.clip.length && checkWrite == false)
        {
            saveToFile();
        }
    }

    void getSpectrumAudioSource()
    {
        song.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
    }

    void getfrequencyrange()
    {
        int currentsample = 0;
        for (int i = 0; i < frequencyRange.Length; i++)
        {
            float average = 0;
            int numberofsamples = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
            {
                numberofsamples += 2;
            }
            for (int j = 0; j < numberofsamples; j++)
            {
                average += samples[currentsample] * (2);
                currentsample++;
            }
            average /= currentsample;
            frequencyRange[i] = average *100;

        }
    }
    void saveToFile()
    {
        float[] timeStampArray = timeStampsOfBeats.ToArray();
        foreach (float timeStamp in timeStampArray)
        {
            System.IO.File.AppendAllText(Application.dataPath + "/brainPower5.txt", Convert.ToString(timeStamp) + Environment.NewLine);
            
        }
        checkWrite = true;
    }

}
