using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterList : MonoBehaviour {
    private GameObject[] charList1;
    private int index1 = 0;

    private void Start()
    {
        //fill array with models
        charList1 = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            charList1[i] = transform.GetChild(i).gameObject;
        }

        // toggle of the renderer for player 1's list
        foreach (GameObject go in charList1)
        {
            go.SetActive(false);

            // we toggle on the first index
            if (charList1[0])
            {
                charList1[0].SetActive(true);
            }
        }
    }

    public void Update()
    {

        //player 1 toggle characters
        if (Input.GetKeyDown(KeyCode.D))
        {
            charList1[index1].SetActive(false);
            index1++;
            if (index1 == charList1.Length)
            {
                index1 = 0;
            }
            charList1[index1].SetActive(true);

        }
        if (Input.GetKey(KeyCode.A))
        {
            charList1[index1].SetActive(false);
            index1--;
            if (index1 < 0)
            {
                index1 = 0;
            }
            charList1[index1].SetActive(true);
        }
        if (Input.GetKey(KeyCode.S))
        {

        }
    }

}
