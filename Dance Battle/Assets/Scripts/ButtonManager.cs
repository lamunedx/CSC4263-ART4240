using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

  public void Play() {
    SceneManager.LoadScene("Game");
  }
  public void SelectCharacter()
    {
        SceneManager.LoadScene("CharacterSelection");
    } 
}
