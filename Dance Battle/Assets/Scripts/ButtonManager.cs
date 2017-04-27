using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This manages all the buttons in the game
public class ButtonManager : MonoBehaviour {
    public GameObject charlist1;
    public GameObject charlist2;
    private GameObject[] charList1;
    private GameObject[] charList2;
    private int index1 = 0;
    private int index2 = 0;

    public void Play() {
        SceneManager.LoadScene("CharacterSelection");
    }

    // List all the playable characters in the game
    public void Players() {
    SceneManager.LoadScene("CharacterEncyclopedia");
    }

    private void Start() {
        //fill array with models
        charList1 = new GameObject[charlist1.transform.childCount];
        charList2 = new GameObject[charlist2.transform.childCount];

        for (int i = 0; i < charlist1.transform.childCount; i++) {
            charList1[i] = charlist1.transform.GetChild(i).gameObject;
            charList2[i] = charlist2.transform.GetChild(i).gameObject;
        }

        // toggle of the renderer for player 1's list
        foreach (GameObject go in charList1) {
            go.SetActive(false);

            // we toggle on the first index
            if (charList1[0]) {
                charList1[0].SetActive(true);
            }
        }

        // toggle of the renderer for player 2's list
        foreach (GameObject go in charList2) {
            go.SetActive(false);

            // we toggle on the first index
            if (charList2[0]) {
                charList2[0].SetActive(true);
            }
        }
    }

    public void ToggleLeft(int player) {
        if (player == 1) {
            charList1[index1].SetActive(false);
            index1--;
            if (index1 < 0) {
                index1 = charList1.Length - 1;
            }
            charList1[index1].SetActive(true);
        }
        else if (player == 2) {
            charList2[index2].SetActive(false);
            index2--;
            if (index2 < 0) {
                index2 = charList2.Length - 1;
            }
            charList2[index2].SetActive(true);
        }
    }

    public void ToggleRight(int player) {
        if (player == 1) {
            charList1[index1].SetActive(false);
            index1++;
            if (index1 == charList1.Length) {
                index1 = 0;
            }
            charList1[index1].SetActive(true);
        }
        else if (player == 2) {
            charList2[index2].SetActive(false);
            index2++;
            if (index2 == charList2.Length) {
                index2 = 0;
            }
            charList2[index2].SetActive(true);
        }
    }

    public void SelectPlayer2Play() {
        SceneManager.LoadScene("Game");
    }
}
