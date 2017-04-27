using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterList : MonoBehaviour
{
    public GameObject CharacterList1;
    public GameObject CharacterList2;
    public Text readyText1;
    public Text readyText2;

    private SpriteRenderer[] charList1;
    private SpriteRenderer[] charList2;
    private int index1 = 0;
    private int index2 = 0;

    public GameObject selectP1;
    public GameObject selectP2;
    private bool p1 = false;
    private bool p2 = false;
    private int p1select;
    private int p2select;

    private bool x_isAxisInUse;
    private bool x1_isAxisInUse;

    private void Awake()
    {
        charList1 = CharacterList1.GetComponentsInChildren<SpriteRenderer>();
        charList2 = CharacterList2.GetComponentsInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        //fill array with models
        x_isAxisInUse = false;
        x1_isAxisInUse = false;

        // toggle of the renderer for player 1's list

    }

    public void Update()
    {

        if (selectP1.transform.position.x == -1.6f && !p1)
        {
            print("Entered");
            if ((Input.GetAxisRaw("LeftJoystickX1") > .5 || Input.GetKeyDown(KeyCode.D)) && !p1)
            {
                
                
                if (Input.GetAxisRaw("LeftJoystickX1") > .5 && x1_isAxisInUse == false)
                {
                    charList1[0].enabled = false;
                    charList1[1].enabled = true;
                    selectP1.transform.Translate(new Vector3(1.6f, 0f));
                    x1_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    charList1[0].enabled = false;
                    charList1[1].enabled = true;
                    selectP1.transform.Translate(new Vector3(1.6f, 0f));
                }
            }
        }
        else if (selectP1.transform.position.x == 1.6f && !p1)
        {
            print("Entered");
            if (Input.GetAxisRaw("LeftJoystickX1") < -.5 || Input.GetKeyDown(KeyCode.A))
            {
                
                if (Input.GetAxisRaw("LeftJoystickX1") < -.5 && x_isAxisInUse == false)
                {
                    charList1[1].enabled = true;
                    selectP1.transform.Translate(new Vector3(-1.6f, 0f));
                    x1_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    charList1[1].enabled = true;
                    selectP1.transform.Translate(new Vector3(-1.6f, 0f));
                };
            }
        }
        else if(!p1)
        {
            
            if (Input.GetAxisRaw("LeftJoystickX1") > .5 || Input.GetKeyDown(KeyCode.D))
            {
                
                if (Input.GetAxisRaw("LeftJoystickX1") > .5 && x1_isAxisInUse == false)
                {
                    charList1[1].enabled = false;
                    selectP1.transform.Translate(new Vector3(1.6f, 0f));
                    x1_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    charList1[1].enabled = false;
                    selectP1.transform.Translate(new Vector3(1.6f, 0f));
                }
            }
            if (Input.GetAxisRaw("LeftJoystickX1") < -.5 || Input.GetKeyDown(KeyCode.A))
            {
                
                if (Input.GetAxisRaw("LeftJoystickX1") < -.5 && x1_isAxisInUse == false)
                {
                    charList1[1].enabled = false;
                    charList1[0].enabled = true;
                    selectP1.transform.Translate(new Vector3(-1.6f, 0f));
                    x1_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    charList1[1].enabled = false;
                    charList1[0].enabled = true;
                    selectP1.transform.Translate(new Vector3(-1.6f, 0f));
                }
            }
        }
        if (Input.GetButtonDown("X1") || Input.GetKeyDown(KeyCode.R))
        {
            if(charList1[0].enabled)
            {
                p1select = 0;
                p1 = true;
                PlayerPrefs.SetString("Player1", "Orange");
                readyText1.enabled = true;
            }
            else if(charList1[1].enabled)
            {
                p1select = 1;
                p1 = true;
                PlayerPrefs.SetString("Player1", "Blue");
                readyText1.enabled = true;
            }
        }

        //Player 2 Select
        if (selectP2.transform.position.x == -1.6f && !p2)
        {
            if (Input.GetAxisRaw("LeftJoystickX") > .5 || Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (Input.GetAxisRaw("LeftJoystickX") > .5 && x_isAxisInUse == false)
                {
                    charList2[0].enabled = false;
                    charList2[1].enabled = true;
                    Debug.Log("IN HERE DUMMY");
                    selectP2.transform.Translate(new Vector3(1.6f, 0f));
                    x_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    charList2[0].enabled = false;
                    charList2[1].enabled = true;
                    selectP2.transform.Translate(new Vector3(1.6f, 0f));
                }
            }
        }

        else if (selectP2.transform.position.x == 1.6f && !p2)
        {

            if (Input.GetAxisRaw("LeftJoystickX") < -.5 || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                
                if (Input.GetAxisRaw("LeftJoystickX") < -.5 && x_isAxisInUse == false)
                {
                    charList2[1].enabled = true;
                    selectP2.transform.Translate(new Vector3(-1.6f, 0f));
                    x_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    charList2[1].enabled = true;
                    selectP2.transform.Translate(new Vector3(-1.6f, 0f));
                }
            }

        }
        else if(!p2)
        {
            if (Input.GetAxisRaw("LeftJoystickX") > .5 || Input.GetKeyDown(KeyCode.RightArrow))
            {
                
                if (Input.GetAxisRaw("LeftJoystickX") > .5 && x_isAxisInUse == false)
                {
                    charList2[1].enabled = false;
                    Debug.Log("No IN HERE DUMMY");
                    selectP2.transform.Translate(new Vector3(1.6f, 0f));
                    x_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    charList2[1].enabled = false;
                    selectP2.transform.Translate(new Vector3(1.6f, 0f));
                }

            }
            if (Input.GetAxisRaw("LeftJoystickX") < -.5 || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                
                if (Input.GetAxisRaw("LeftJoystickX") < -.5 && x_isAxisInUse == false)
                {
                    charList2[1].enabled = false;
                    charList2[0].enabled = true;
                    selectP2.transform.Translate(new Vector3(-1.6f, 0f));
                    x_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    charList2[1].enabled = false;
                    charList2[0].enabled = true;
                    selectP2.transform.Translate(new Vector3(-1.6f, 0f));
                }

            }

        }
        if (Input.GetButtonDown("X") || Input.GetKeyDown(KeyCode.K))
        {
            if (charList2[0].enabled)
            {
                p2select = 0;
                p2 = true;
                PlayerPrefs.SetString("Player2", "Orange");
                readyText2.enabled = true;
            }
            else if (charList2[1].enabled)
            {
                p2select = 1;
                p2 = true;
                PlayerPrefs.SetString("Player2", "Blue");
                readyText2.enabled = true;
            }
        }
        if (Input.GetAxisRaw("LeftJoystickX") == 0)
        {
            x_isAxisInUse = false;
        }
        if (Input.GetAxisRaw("LeftJoystickX1") == 0)
        {
            x1_isAxisInUse = false;
        }

        // ready to start da fight!!!
        if(p1 && p2)
        {
            SceneManager.LoadScene("MahdiGameTestingScene");
        }
        //player 1 toggle characters
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    charList1[index1].SetActive(false);
        //    index1++;
        //    if (index1 == charList1.Length)
        //    {
        //        index1 = 0;
        //    }
        //    charList1[index1].SetActive(true);

        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    charList1[index1].SetActive(false);
        //    index1--;
        //    if (index1 < 0)
        //    {
        //        index1 = 0;
        //    }
        //    charList1[index1].SetActive(true);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{

        //}
    }

}
