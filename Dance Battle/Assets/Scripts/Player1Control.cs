using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// player 1's control script
public class Player1Control : MonoBehaviour
{

    private Animator anime;
    private Rigidbody2D rigid;
    public float playerHealth = 100f;
    protected float damage = 5f;
    public Slider healthSlider;

    // reference to the other player
    public GameObject otherPlayer;
    private Rigidbody2D otherRigid;

    public GameObject punch1;
    //public GameObject punch2;
    public GameObject kick;
    //public GameObject throwDuck;
    //public GameObject block;

    private CircleCollider2D punch1Col;
    private CapsuleCollider2D kickCol;
    private float attackTime;

    private CapsuleCollider2D[] capColliders;

    public GameObject gameController;

    public Text fightOver;


    void Awake()
    {
        anime = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();

        otherRigid = otherPlayer.GetComponent<Rigidbody2D>();

        punch1Col = punch1.GetComponent<CircleCollider2D>();
        kickCol = kick.GetComponent<CapsuleCollider2D>();
        attackTime = Time.time;

        capColliders = gameObject.GetComponents<CapsuleCollider2D>();
    }

    void Update()
    {
        // movement keys -----------------------------------------------------------
        if (Input.GetKey(KeyCode.D) && !anime.GetBool("crouching"))
        {
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
            anime.SetBool("moving", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anime.SetBool("moving", false);
        }

        if (Input.GetKey(KeyCode.A) && !anime.GetBool("crouching"))
        {
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
            anime.SetBool("moving", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anime.SetBool("moving", false);
        }

        if (Input.GetKey(KeyCode.S) && anime.GetBool("onGround"))
        {
            anime.SetBool("crouching", true);
            capColliders[0].offset = new Vector2(capColliders[0].offset.x, -1f);
            capColliders[2].offset = new Vector2(capColliders[2].offset.x, 0f);


        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            //cap[1].enabled = false;
            //cap[0].enabled = true;
            //GetComponentInChildren<EdgeCollider2D>().enabled = true;
            //transform.position = new Vector2(transform.localPosition.x, -2.96f);
            anime.SetBool("crouching", false);
            capColliders[0].offset = new Vector2(capColliders[0].offset.x, .17f);
            capColliders[2].offset = new Vector2(capColliders[2].offset.x, 1.02f);
            
        }

        if (Input.GetKeyDown(KeyCode.W) && anime.GetBool("onGround"))
        {
            rigid.AddForce(Vector2.up * 575f);
        }

        // action keys -------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Z) && !anime.GetBool("moving") && Time.time > attackTime + .6 && anime.GetBool("onGround"))
        {
            anime.SetBool("punching", true);
            punch1Col.enabled = true;
            Debug.Log("punch");
            attackTime = Time.time;
        }
        if (Input.GetKey(KeyCode.Z) && !anime.GetBool("moving") && Time.time > attackTime + .6 && anime.GetBool("onGround"))
        {
            anime.SetBool("punching", false);
            punch1Col.enabled = false;

        }
        if (Input.GetKeyUp(KeyCode.Z) && anime.GetBool("punching"))
        {
            anime.SetBool("punching", false);
            punch1Col.enabled = false;
            Debug.Log("punchStop");
        }
        if (Input.GetKeyDown(KeyCode.X) && !anime.GetBool("moving") && Time.time > attackTime + .65 && anime.GetBool("onGround"))
        {
            anime.SetBool("kicking", true);
            kickCol.enabled = true;
            attackTime = Time.time;
        }
        if (Input.GetKey(KeyCode.X) && !anime.GetBool("moving") && Time.time > attackTime + .65 && anime.GetBool("onGround"))
        {
            anime.SetBool("kicking", false);
            kickCol.enabled = false;

        }
        if (Input.GetKeyUp(KeyCode.X) && anime.GetBool("kicking"))
        {
            anime.SetBool("kicking", false);
            kickCol.enabled = false;
        }

        // make sure the player is facing the right direction
        // note: this handles both players, so don't add this to the player 1 script
        if (rigid.position.x > otherRigid.position.x)
        {
            rigid.transform.localScale = new Vector2(2f, rigid.transform.localScale.y);
            otherRigid.transform.localScale = new Vector2(-2f, otherRigid.transform.localScale.y);
        }
        else
        {
            rigid.transform.localScale = new Vector2(-2f, rigid.transform.localScale.y);
            otherRigid.transform.localScale = new Vector2(2f, otherRigid.transform.localScale.y);
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
            fightOver.text = "PLAYER 2 WINS";
            otherPlayer.GetComponent<Player2Control>().enabled = false;
            this.GetComponent<Player1Control>().enabled = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            anime.SetBool("onGround", true);
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
        if (collider.gameObject.tag == "P2punch1")
        {
            playerHealth -= 5;
            healthSlider.value = playerHealth;
        }
        if (collider.gameObject.tag == "P2punch2")
        {
            playerHealth -= 7;
            healthSlider.value = playerHealth;
        }
        if (collider.gameObject.tag == "P2kick")
        {
            playerHealth -= 10;
            healthSlider.value = playerHealth;
        }
        if (collider.gameObject.tag == "P2throwChicken")
        {
            playerHealth -= 2;
            healthSlider.value = playerHealth;
        }
    }

}
