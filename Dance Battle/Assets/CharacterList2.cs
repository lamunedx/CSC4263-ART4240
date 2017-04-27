using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList2 : MonoBehaviour {
    private GameObject[] charList2;
    private int index2 = 0;

    private void Start()
    {
        //fill array with models
        charList2 = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            charList2[i] = transform.GetChild(i).gameObject;
        }

        // toggle of the renderer for player 2's list
        foreach (GameObject go in charList2)
        {
            go.SetActive(false);

            // we toggle on the first index
            if (charList2[0])
            {
                charList2[0].SetActive(true);
            }
        }
    }

    public void Update()
    {
        
        //player 2 toggle characters
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            charList2[index2].SetActive(false);
            index2++;
            if (index2 == charList2.Length)
            {
                index2 = 0;
            }
            charList2[index2].SetActive(true);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            charList2[index2].SetActive(false);
            index2--;
            if (index2 < 0)
            {
                index2 = 0;
            }
            charList2[index2].SetActive(true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {

        }
    }
}
