using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// player 2's control script
public class Player2Control : MonoBehaviour
{

    private Animator anime;
    private Rigidbody2D rigid;
    public float playerHealth = 100f;
    protected float damage = 5f;
    public Slider healthSlider;
    // reference to the other player
    public GameObject otherPlayer;
    public GameObject punch1;
    public GameObject punch2;
    public GameObject kick;
    public GameObject uppercut;
    //public GameObject throwDuck;
    //public GameObject block;
    private float attackTime;
    private CapsuleCollider2D[] capColliders;
    public GameObject gameController;
    public Text fightOver;
    private bool grounded;
    private bool uc;

    void Awake()
    {
        anime = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();

        attackTime = Time.time;

        capColliders = gameObject.GetComponents<CapsuleCollider2D>();
        grounded = true;
        uc = false;
    }

    void Update()
    {   //uppercut combo
        if (uc == false)
        {
            if (((Input.GetButtonDown("A") && Input.GetButton("Y")) || ((Input.GetKeyDown(KeyCode.K)) && Input.GetKeyDown(KeyCode.UpArrow))) && !anime.GetBool("moving") && Time.time > attackTime + .3 && anime.GetBool("onGround"))
            {
                anime.SetBool("uppercut", true);
                uppercut.transform.Translate(new Vector3(-.96f*2, 1.24f, 0));
                attackTime = Time.time;
                uc = true;
            }
        }
        //Stop uppercut on release
        else
        {

            anime.SetBool("uppercut", false);
            uppercut.transform.Translate(new Vector3(.96f * 2, -1.240f, 0));
            uc = false; 

        }
        // movement keys -----------------------------------------------------------
        //Right
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("LeftJoystickX") > 0) && !anime.GetBool("crouching"))
        {
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
            anime.SetBool("moving", true);
        }
        //Left
        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("LeftJoystickX") < 0) && !anime.GetBool("crouching"))
        {
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
            anime.SetBool("moving", true);
        }
        //crouch
        else if (Input.GetAxis("LeftJoystickY") == -1 && anime.GetBool("onGround") || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            anime.SetBool("moving", false);
            anime.SetBool("crouching", true);
            capColliders[0].offset = new Vector2(capColliders[0].offset.x, -1f);
            capColliders[2].offset = new Vector2(capColliders[2].offset.x, 0f);
            kick.transform.position = new Vector3(kick.transform.position.x, -8f, 0);
            punch1.transform.position = new Vector3(kick.transform.position.x, -8f, 0);

        }
        //Jump
        else if ((Input.GetButtonDown("Y") || Input.GetKeyDown(KeyCode.UpArrow)) && grounded)
        {
            rigid.AddForce(Vector2.up * 575f);
        }
        //uncrouch
        if ((Input.GetAxis("LeftJoystickY") == 0) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anime.SetBool("crouching", false);
            capColliders[0].offset = new Vector2(capColliders[0].offset.x, .17f);
            capColliders[2].offset = new Vector2(capColliders[2].offset.x, 1.02f);
            kick.transform.position = new Vector3(kick.transform.position.x, 0f, 0);
            punch1.transform.position = new Vector3(kick.transform.position.x, 0f, 0);
        }
        //stand still
        if ((Input.GetAxis("LeftJoystickX") == 0) || (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)))
        {
            anime.SetBool("moving", false);
        }

        // action keys -------------------------------------------------------------
        //punch1
        if ((Input.GetButtonDown("X") || Input.GetKeyDown(KeyCode.J)) && !anime.GetBool("moving") && Time.time > attackTime + .2 && anime.GetBool("onGround"))
        {
            anime.SetBool("punching", true);
            punch1.transform.Translate(new Vector3(-3.04f, 0, 0));
            attackTime = Time.time;
        }
        //punch 2
        else if ((Input.GetButtonDown("A") || Input.GetKeyDown(KeyCode.K)) && !anime.GetBool("moving") && Time.time > attackTime + .2 && anime.GetBool("onGround"))
        {
            anime.SetBool("punch2", true);
            punch2.transform.Translate(new Vector3(-2.33f, 0, 0));
            attackTime = Time.time;
        }
        //kick
        else if ((Input.GetButtonDown("B") || Input.GetKeyDown(KeyCode.O)) && !anime.GetBool("moving") && Time.time > attackTime + .6 && anime.GetBool("onGround"))
        {
            anime.SetBool("kicking", true);
            //kickCol.enabled = true;
            kick.transform.Translate(new Vector3(-2.06f, 0, 0));
            attackTime = Time.time;
        }
        //Stop punching 1  on release
        if ((Input.GetButtonUp("X") || Input.GetKeyUp(KeyCode.J)) && anime.GetBool("punching"))
        {

            anime.SetBool("punching", false);
            punch1.transform.Translate(new Vector3(3.04f, 0, 0));

        }

        //Stop punch 2 if released
        if ((Input.GetButtonUp("A") || Input.GetKeyUp(KeyCode.K)) && anime.GetBool("punch2"))
        {

            anime.SetBool("punch2", false);
            punch2.transform.Translate(new Vector3(2.33f, 0, 0));

        }
        
        if ((Input.GetButtonUp("B") || Input.GetKeyUp(KeyCode.O)) && anime.GetBool("kicking"))
        {
            anime.SetBool("kicking", false);
            kick.transform.Translate(new Vector3(2.06f, 0, 0));
            //kickCol.enabled = false;
        }
        if (playerHealth <= 0)
        {
            anime.SetBool("crouching", true);
            otherPlayer.GetComponent<Animator>().SetBool("punching", false);
            otherPlayer.GetComponent<Animator>().SetBool("kicking", false);
            otherPlayer.GetComponent<Animator>().SetBool("moving", false);
            gameController.GetComponent<fightTime>().enabled = false;
            gameController.GetComponent<fightTime>().StopAllCoroutines();
            fightOver.fontSize = 200;
            fightOver.text = "PLAYER 1 WINS";
            otherPlayer.GetComponent<Player1Control>().enabled = false;
            this.GetComponent<Player2Control>().enabled = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            anime.SetBool("onGround", true);
            anime.SetBool("jumping", false);
            grounded = true;
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
            grounded = true;
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
            grounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "P1punch1")
        {
            playerHealth -= 5;
            healthSlider.value = playerHealth;
            Debug.Log("player 1 punched me");
        }
        if (collider.gameObject.tag == "P1punch2")
        {
            playerHealth -= 3;
            healthSlider.value = playerHealth;
        }
        if (collider.gameObject.tag == "P1Uppercut")
        {
            playerHealth -= 15;
            healthSlider.value = playerHealth;
        }
        if (collider.gameObject.tag == "P1kick")
        {
            playerHealth -= 10;
            healthSlider.value = playerHealth;
        }
        if (collider.gameObject.tag == "P1throwChicken")
        {
            playerHealth -= 2;
            healthSlider.value = playerHealth;
        }
    }

}
