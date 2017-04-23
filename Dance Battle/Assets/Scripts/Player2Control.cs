﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player 2's control script
public class Player2Control : MonoBehaviour
{

    private Animator anime;
    private Rigidbody2D rigid;
    public float playerHealth = 100f;
    protected float damage = 5f;

    // reference to the other player
    public GameObject otherPlayer;

    public GameObject punch1;
    //public GameObject punch2;
    public GameObject kick;
    //public GameObject throwDuck;
    //public GameObject block;

    private CircleCollider2D punch1Col;
    private CapsuleCollider2D kickCol;
    private float attackTime;

    void Start()
    {
        anime = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();

        punch1Col = punch1.GetComponent<CircleCollider2D>();
        kickCol = kick.GetComponent<CapsuleCollider2D>();
        attackTime = Time.time;
    }

    void Update()
    {
        // movement keys -----------------------------------------------------------
        if (Input.GetKey(KeyCode.RightArrow) && !anime.GetBool("crouching"))
        {
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
            anime.SetBool("moving", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anime.SetBool("moving", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !anime.GetBool("crouching"))
        {
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
            anime.SetBool("moving", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anime.SetBool("moving", false);
        }

        if (Input.GetKey(KeyCode.DownArrow) && anime.GetBool("onGround"))
        {
            //cap[0].enabled = false;
            //cap[1].enabled = true;
            //GetComponentInChildren<EdgeCollider2D>().enabled = false;
            //transform.position = new Vector2(transform.localPosition.x, -3.24f);
            anime.SetBool("crouching", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //cap[1].enabled = false;
            //cap[0].enabled = true;
            //GetComponentInChildren<EdgeCollider2D>().enabled = true;
            //transform.position = new Vector2(transform.localPosition.x, -2.96f);
            anime.SetBool("crouching", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && anime.GetBool("onGround"))
        {
            rigid.AddForce(Vector2.up * 575f);
        }

        // action keys -------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.I) && !anime.GetBool("moving") && Time.time > attackTime + .6)
        {
            anime.SetBool("punching", true);
            punch1Col.enabled = true;
            Debug.Log("punch");
            attackTime = Time.time;
        }
        if (Input.GetKey(KeyCode.I) && !anime.GetBool("moving") && Time.time > attackTime + .6)
        {
            anime.SetBool("punching", false);
            punch1Col.enabled = false;

        }
        if (Input.GetKeyUp(KeyCode.I) && anime.GetBool("punching"))
        {
            anime.SetBool("punching", false);
            punch1Col.enabled = false;
            Debug.Log("punchStop");
        }
        if (Input.GetKeyDown(KeyCode.O) && !anime.GetBool("moving") && Time.time > attackTime + .6)
        {
            anime.SetBool("kicking", true);
            kickCol.enabled = true;
            attackTime = Time.time;
        }
        if (Input.GetKey(KeyCode.O) && !anime.GetBool("moving") && Time.time > attackTime + .6)
        {
            anime.SetBool("kicking", false);
            kickCol.enabled = false;

        }
        if (Input.GetKeyUp(KeyCode.O) && anime.GetBool("kicking"))
        {
            anime.SetBool("kicking", false);
            kickCol.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            anime.SetBool("onGround", true);
            anime.SetBool("jumping", false);
        }
        if (collision.gameObject.name == "Player2")
        {
            anime.SetBool("jumping", false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            anime.SetBool("onGround", true);
            anime.SetBool("jumping", false);
        }
        if (collision.gameObject.name == "Player2")
        {
            anime.SetBool("jumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            anime.SetBool("onGround", false);
            anime.SetBool("jumping", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "P1punch1")
        {
            playerHealth -= 5;
            Debug.Log("player 1 punched me");
        }
        if (collider.gameObject.tag == "P1punch2")
        {
            playerHealth -= 7;
        }
        if (collider.gameObject.tag == "P1kick")
        {
            playerHealth -= 10;
        }
        if (collider.gameObject.tag == "P1throwChicken")
        {
            playerHealth -= 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "P1punch1")
        {
           
            Debug.Log("player 1 punched me");
        }
        if (collider.gameObject.tag == "P1punch2")
        {
            
        }
        if (collider.gameObject.tag == "P1kick")
        {
            
        }
        if (collider.gameObject.tag == "P1throwChicken")
        {
            
        }
    }
}
