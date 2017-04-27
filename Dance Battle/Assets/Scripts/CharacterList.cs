using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterList : MonoBehaviour
{
    private GameObject[] charList1;
    private int index1 = 0;

    public GameObject selectP1;
    public GameObject selectP2;

    private bool x_isAxisInUse;
    private bool x1_isAxisInUse;

    private void Start()
    {
        //fill array with models
        charList1 = new GameObject[transform.childCount];
        x_isAxisInUse = false;
        x1_isAxisInUse = false;

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
        if (selectP1.transform.position.x == -1.6f)
        {
            print("Entered");
            if (Input.GetAxisRaw("LeftJoystickX1") > .95 || Input.GetKeyDown(KeyCode.D))
            {
                if (Input.GetAxisRaw("LeftJoystickX1") > .9 && x1_isAxisInUse == false)
                {
                    selectP1.transform.Translate(new Vector3(1.6f, 0f));
                    x1_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    selectP1.transform.Translate(new Vector3(1.6f, 0f));
                }
            }
        }
        else if (selectP1.transform.position.x == 1.6f)
        {
            print("Entered");
            if (Input.GetAxisRaw("LeftJoystickX1") < -.95 || Input.GetKeyDown(KeyCode.A))
            {

                if (Input.GetAxisRaw("LeftJoystickX1") < -.5 && x_isAxisInUse == false)
                {
                    selectP1.transform.Translate(new Vector3(-1.6f, 0f));
                    x1_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    selectP1.transform.Translate(new Vector3(-1.6f, 0f));
                };
            }
        }
        else
        {
            if (Input.GetAxisRaw("LeftJoystickX1") > .95 || Input.GetKeyDown(KeyCode.D))
            {
                if (Input.GetAxisRaw("LeftJoystickX1") > .9 && x1_isAxisInUse == false)
                {
                    selectP1.transform.Translate(new Vector3(1.6f, 0f));
                    x1_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    selectP1.transform.Translate(new Vector3(1.6f, 0f));
                }
            }
            else if (Input.GetAxisRaw("LeftJoystickX1") < -.95 || Input.GetKeyDown(KeyCode.A))
            {
                if (Input.GetAxisRaw("LeftJoystickX1") < -.5 && x1_isAxisInUse == false)
                {
                    selectP1.transform.Translate(new Vector3(-1.6f, 0f));
                    x1_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    selectP1.transform.Translate(new Vector3(-1.6f, 0f));
                }
            }
        }

        //Player 2 Select
        if (selectP2.transform.position.x == -1.6f)
        {
            if (Input.GetAxisRaw("LeftJoystickX") > .9 || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Input.GetAxisRaw("LeftJoystickX") > .9 && x_isAxisInUse == false)
                {
                    selectP2.transform.Translate(new Vector3(1.6f, 0f));
                    x_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    selectP2.transform.Translate(new Vector3(1.6f, 0f));
                }
            }
        }

        else if (selectP2.transform.position.x == 1.6f)
        {
            if (Input.GetAxisRaw("LeftJoystickX") < -.5 || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (Input.GetAxisRaw("LeftJoystickX") < -.5 && x_isAxisInUse == false)
                {
                    selectP2.transform.Translate(new Vector3(-1.6f, 0f));
                    x_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    selectP2.transform.Translate(new Vector3(-1.6f, 0f));
                }
            }

        }
        else
        {
            if (Input.GetAxisRaw("LeftJoystickX") > .5 || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Input.GetAxisRaw("LeftJoystickX") > .5 && x_isAxisInUse == false)
                {
                    selectP2.transform.Translate(new Vector3(1.6f, 0f));
                    x_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    selectP2.transform.Translate(new Vector3(1.6f, 0f));
                }

            }
            if (Input.GetAxisRaw("LeftJoystickX") < -.5 || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (Input.GetAxisRaw("LeftJoystickX") < -.5 && x_isAxisInUse == false)
                {
                    selectP2.transform.Translate(new Vector3(-1.6f, 0f));
                    x_isAxisInUse = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    selectP2.transform.Translate(new Vector3(-1.6f, 0f));
                }

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
