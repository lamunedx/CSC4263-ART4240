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

        punch1Col = punch1.GetComponent<CircleCollider2D>();
        kickCol = kick.GetComponent<CapsuleCollider2D>();
        attackTime = Time.time;

        capColliders = gameObject.GetComponents<CapsuleCollider2D>();
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

        if (Input.GetKey(KeyCode.LeftArrow)  && !anime.GetBool("crouching"))
        {
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
            anime.SetBool("moving", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anime.SetBool("moving", false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && anime.GetBool("onGround"))
        {
            anime.SetBool("moving", false);
            anime.SetBool("crouching", true);
            capColliders[0].offset = new Vector2(capColliders[0].offset.x, -1f);
            capColliders[2].offset = new Vector2(capColliders[2].offset.x, 0f);
            kick.transform.Translate(new Vector3(0, -2f, 0));
            punch1.transform.Translate(new Vector3(0, -2f, 0));

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && anime.GetBool("onGround"))
        {
            anime.SetBool("crouching", true);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //cap[1].enabled = false;
            //cap[0].enabled = true;
            //GetComponentInChildren<EdgeCollider2D>().enabled = true;
            //transform.position = new Vector2(transform.localPosition.x, -2.96f);
            anime.SetBool("crouching", false);
            capColliders[0].offset = new Vector2(capColliders[0].offset.x, .17f);
            capColliders[2].offset = new Vector2(capColliders[2].offset.x, 1.02f);
            kick.transform.Translate(new Vector3(0, 2f, 0));
            punch1.transform.Translate(new Vector3(0, 2f, 0));

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && anime.GetBool("onGround"))
        {
            rigid.AddForce(Vector2.up * 575f);
        }

        // action keys -------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.I) && !anime.GetBool("moving") && Time.time > attackTime + .8 && anime.GetBool("onGround"))
        {
            anime.SetBool("punching", true);
            punch1.transform.Translate(new Vector3(-3.04f, 0, 0));
            Debug.Log("punch");
            attackTime = Time.time;
        }
        //if (Input.GetKey(KeyCode.I) && !anime.GetBool("moving") && Time.time > attackTime + .8 && anime.GetBool("onGround"))
        //{
        //    anime.SetBool("punching", false);
        //    punch1Col.enabled = false;

        //}
        if (Input.GetKeyUp(KeyCode.I) && anime.GetBool("punching"))
        {
            anime.SetBool("punching", false);
            punch1.transform.Translate(new Vector3(3.04f, 0, 0));
            Debug.Log("punchStop");
        }
        if (Input.GetKeyDown(KeyCode.O) && !anime.GetBool("moving") && Time.time > attackTime + .8 && anime.GetBool("onGround"))
        {
            anime.SetBool("kicking", true);
            //kickCol.enabled = true;
            kick.transform.Translate(new Vector3(-2.06f, 0, 0));
            attackTime = Time.time;
        }
        //if (Input.GetKey(KeyCode.O) && !anime.GetBool("moving") && Time.time > attackTime + .8 && anime.GetBool("onGround"))
        //{
        //    anime.SetBool("kicking", false);
        //    kick.transform.Translate(new Vector3(1.03f, 0, 0));
        //    //kickCol.enabled = false;

        //}
        if (Input.GetKeyUp(KeyCode.O) && anime.GetBool("kicking"))
        {
            anime.SetBool("kicking", false);
            kick.transform.Translate(new Vector3(2.06f, 0, 0));
            //kickCol.enabled = false;
        }
        if(playerHealth <= 0)
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
            healthSlider.value = playerHealth;
            Debug.Log("player 1 punched me");
        }
        if (collider.gameObject.tag == "P1punch2")
        {
            playerHealth -= 7;
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
