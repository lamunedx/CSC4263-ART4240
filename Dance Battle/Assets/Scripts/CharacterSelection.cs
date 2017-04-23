using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    private GameObject[] characterList;
    private int index = 0;

    private void Start()
    {
        //fill array with models
        characterList = new GameObject[transform.childCount];

        for (int i=0 ; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        // toggle of the renderer
        foreach (GameObject go in characterList)
            {
                go.SetActive(false);

                //we toggle on the first index
                if (characterList[0])
                {
                    characterList[0].SetActive(true);
                }
                    
            }
    }

    public void ToggleLeft()
    {
        //Toggle of the current model
        characterList[index].SetActive(false);
        index--;
        if(index < 0)
        {
            index = characterList.Length - 1;
        }
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        //Toggle of the current model
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }
        characterList[index].SetActive(true);
    }

    public void SelectPlayer1()
    {
        SceneManager.LoadScene("Player2Selection");
    }
    public void SelectPlayer2Play()
    {
        SceneManager.LoadScene("Game");
    }

}
