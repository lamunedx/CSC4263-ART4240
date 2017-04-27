using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterList : MonoBehaviour {
    public GameObject Player1CharacterList;
    public GameObject Player2CharacterList;
    private GameObject[] charList1;
    private GameObject[] charList2;
    private int index1 = 0;
    private int index2 = 0;

    private void Start()
    {
        //fill array with models
        charList1 = new GameObject[Player1CharacterList.transform.childCount];
        charList2 = new GameObject[Player2CharacterList.transform.childCount];

        for (int i = 0; i < Player1CharacterList.transform.childCount; i++)
        {
            charList1[i] = Player1CharacterList.transform.GetChild(i).gameObject;
            charList2[i] = Player2CharacterList.transform.GetChild(i).gameObject;
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
        else if (Input.GetKey(KeyCode.A))
        {
            charList1[index1].SetActive(false);
            index1--;
            if (index1 < 0)
            {
                index1 = 0;
            }
            charList1[index1].SetActive(true);
        }
        else if (Input.GetKey(KeyCode.S))
        {

        }

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
