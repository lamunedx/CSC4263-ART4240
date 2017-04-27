using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This manages all the buttons in the game
public class ButtonManager : MonoBehaviour {
    public void Play() {
        SceneManager.LoadScene("MahdiGameTestingScene");
    }

    // List all the playable characters in the game
    public void Players() {
    SceneManager.LoadScene("CharacterSelectionNew");
    }
}
