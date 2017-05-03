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
    public GameObject punch2;
    public GameObject kick;
    public GameObject uppercut;
    //public GameObject throwDuck;
    //public GameObject block;
    private float attackTime;
    private CapsuleCollider2D[] capColliders;
    public GameObject gameController;
    public Canvas endFight;
    public Image player2wins;
    private bool grounded;
    private bool uc;
	private bool controller = false;
	private AudioSource hitting;


    void Awake()
    {
        anime = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();

        otherRigid = otherPlayer.GetComponent<Rigidbody2D>();

        attackTime = Time.time;

        capColliders = gameObject.GetComponents<CapsuleCollider2D>();
        grounded = true;
        uc = false;
        string[] joysticks = Input.GetJoystickNames();

        if (joysticks.Length != 0){
            controller = true;
		}
		hitting = GetComponent<AudioSource> ();
    }

    void Update()
    {
        //uppercut combo
        if (!uc)
        {
            if (((Input.GetButtonDown("A1") && Input.GetAxis("LeftJoystickY1") > 0) || (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.W))) && !anime.GetBool("moving") && Time.time > attackTime + .8 && anime.GetBool("onGround") && !anime.GetBool("uppercut") && !anime.GetBool("blocking"))
            {
                uppercut.SetActive(true);
                anime.SetBool("uppercut", true);
                uppercut.transform.Translate(new Vector3(-3.3f, 1.24f, 0));
                attackTime = Time.time;
                uc = true;
            }
        }
        //Stop uppercut on release
        else
        {
            //uppercut.SetActive(false);
            anime.SetBool("uppercut", false);
            uppercut.transform.Translate(new Vector3(3.3f, -1.240f, 0));
            uc = false;

        }
        // movement keys -----------------------------------------------------------
        //Right
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D) || Input.GetAxis("LeftJoystickX1") > 0) && !anime.GetBool("crouching") && !anime.GetBool("blocking"))
        {
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
            anime.SetBool("moving", true);
        }
        //Left
        else if ((Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A) || Input.GetAxis("LeftJoystickX1") < 0) && !anime.GetBool("crouching") && !anime.GetBool("blocking"))
        {
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
            anime.SetBool("moving", true);
        }
        //crouch
        else if ((Input.GetAxis("LeftJoystickY1") < 0 || Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S)) && anime.GetBool("onGround"))
        {
            anime.SetBool("moving", false);
            anime.SetBool("crouching", true);
            capColliders[0].offset = new Vector2(capColliders[0].offset.x, -1f);
            capColliders[2].offset = new Vector2(capColliders[2].offset.x, 0f);
            kick.transform.position = new Vector3(kick.transform.position.x, -8f, 0);
            punch1.transform.position = new Vector3(punch1.transform.position.x, -8f, 0);

        }
        //Jump
        else if ((Input.GetButtonDown("Y1") || Input.GetKeyDown(KeyCode.Space)) && grounded)
        {
            anime.SetBool("jumping", true);
            rigid.AddForce(Vector2.up * 575f);
        }
        //uncrouch
		else if (((Input.GetAxis("LeftJoystickY1") == 0) && controller)|| Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.S))
        {
            anime.SetBool("crouching", false);
            capColliders[0].offset = new Vector2(capColliders[0].offset.x, .17f);
            capColliders[2].offset = new Vector2(capColliders[2].offset.x, 1.02f);
            kick.transform.position = new Vector3(kick.transform.position.x, 0f, 0);
            punch1.transform.position = new Vector3(punch1.transform.position.x, 0f, 0);
        }
        //stand still
        if (Input.GetKeyUp(KeyCode.A)){
            anime.SetBool("moving", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anime.SetBool("moving", false);

        }
        if ((Input.GetAxis("LeftJoystickX1") == 0 && controller))
        {
            anime.SetBool("moving", false);
        }

        // action keys -------------------------------------------------------------
        //punch1
        if ((Input.GetButtonDown("X1") || Input.GetKeyDown(KeyCode.R)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .2 && anime.GetBool("onGround") && !anime.GetBool("punching") && !anime.GetBool("blocking") && !anime.GetBool("crouching")  && !anime.GetBool("jumping"))
        {
            punch1.SetActive(true);
            anime.SetBool("punching", true);
            punch1.transform.Translate(new Vector3(-3.04f, 0, 0));
            attackTime = Time.time;
        }
        //punch 2
        else if ((Input.GetButtonDown("A1") || Input.GetKeyDown(KeyCode.E)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .2 && anime.GetBool("onGround") && !anime.GetBool("punch2") && !anime.GetBool("blocking") && !anime.GetBool("crouching") && !anime.GetBool("jumping"))
        {
            punch2.SetActive(true);
            anime.SetBool("punch2", true);
            punch2.transform.Translate(new Vector3(-2.33f, 0, 0));
            attackTime = Time.time;
        }
        //kick
        else if ((Input.GetButtonDown("B1") || Input.GetKeyDown(KeyCode.F)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .35 && anime.GetBool("onGround") && !anime.GetBool("kicking") && !anime.GetBool("blocking") && !anime.GetBool("crouching") && !anime.GetBool("jumping"))
        {
            kick.SetActive(true);
            anime.SetBool("kicking", true);
            kick.transform.Translate(new Vector3(-2.06f, 0, 0));
            attackTime = Time.time;
        }
        //block
        else if ((Input.GetButtonDown("RB1") || Input.GetButtonDown("LB1") || Input.GetKeyDown(KeyCode.Q)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && anime.GetBool("onGround"))
        {
            anime.SetBool("blocking", true);
            capColliders[0].enabled = false;
        }
        //stops punch 1 on hold
        if ((Input.GetButton("X1") || Input.GetKey(KeyCode.R)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .2 && anime.GetBool("onGround") && anime.GetBool("punching"))
        {
            anime.SetBool("punching", false);
            punch1.transform.Translate(new Vector3(3.04f, 0, 0));
            attackTime = Time.time;
            //punch1.SetActive(false);
        }
        //stops punch 2 on hold
        if ((Input.GetButton("A1") || Input.GetKey(KeyCode.E)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .2&& anime.GetBool("onGround") && anime.GetBool("punch2"))
        {
            anime.SetBool("punch2", false);
            punch2.transform.Translate(new Vector3(2.33f, 0, 0));
            attackTime = Time.time;
            //punch2.SetActive(false);
        }
        //stops kick 1 on hold
        if ((Input.GetButton("B1") || Input.GetKey(KeyCode.F)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .35 && anime.GetBool("onGround") && anime.GetBool("kicking"))
        {
            anime.SetBool("kicking", false);
            kick.transform.Translate(new Vector3(2.06f, 0, 0));
            attackTime = Time.time;
            //kick.SetActive(false);
        }
        //block on hold
        if ((Input.GetButton("RB1") || Input.GetButton("LB1") || Input.GetKey(KeyCode.Q)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && anime.GetBool("onGround"))
        {
            anime.SetBool("blocking", true);
            capColliders[0].enabled = false;

        }
        //Stop punching 1  on release
        if ((Input.GetButtonUp("X1") || Input.GetKeyUp(KeyCode.R)) && anime.GetBool("punching"))
        {
            anime.SetBool("punching", false);
            punch1.transform.Translate(new Vector3(3.04f, 0, 0));
            //punch1.SetActive(false);
        }

        //Stop punch 2 if released
        if ((Input.GetButtonUp("A1") || Input.GetKeyUp(KeyCode.E)) && anime.GetBool("punch2"))
        {
            anime.SetBool("punch2", false);
            punch2.transform.Translate(new Vector3(2.33f, 0, 0));
            //punch2.SetActive(false);
        }
        //Stop kick if released
        if ((Input.GetButtonUp("B1") || Input.GetKeyUp(KeyCode.F)) && anime.GetBool("kicking"))
        {
            anime.SetBool("kicking", false);
            kick.transform.Translate(new Vector3(2.06f, 0, 0));
            //kick.SetActive(false);
            //kickCol.enabled = false;
        }
        //stop block on release
        if ((Input.GetButtonUp("RB1")|| Input.GetButtonUp("LB1") || Input.GetKeyUp(KeyCode.Q)) &&  anime.GetBool("blocking"))
        {
            anime.SetBool("blocking", false);
            capColliders[0].enabled = true;

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

            anime.SetBool("punching", false);
            anime.SetBool("punch2", false);
            anime.SetBool("uppercut", false);
            anime.SetBool("kicking", false);
            anime.SetBool("jumping", false);
            anime.SetBool("moving", false);
            anime.SetBool("crouching", false);
            anime.SetBool("damaged", false);
            anime.SetBool("blocking", false);
            otherPlayer.GetComponent<Animator>().SetBool("punching", false);
            otherPlayer.GetComponent<Animator>().SetBool("punch2", false);
            otherPlayer.GetComponent<Animator>().SetBool("uppercut", false);
            otherPlayer.GetComponent<Animator>().SetBool("kicking", false);
            otherPlayer.GetComponent<Animator>().SetBool("moving", false);
            otherPlayer.GetComponent<Animator>().SetBool("jumping", false);
            otherPlayer.GetComponent<Animator>().SetBool("crouching", false);
            otherPlayer.GetComponent<Animator>().SetBool("damaged", false);
            gameController.GetComponent<fightTime>().enabled = false;
            gameController.GetComponent<fightTime>().StopAllCoroutines();
            endFight.enabled = true;
            player2wins.enabled = true;
            transform.Translate(1, 0, -1f);
            anime.Play("koed");
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
            grounded = true;
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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            anime.SetBool("onGround", false);
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "P2punch1")
        {
            playerHealth -= 5;
            healthSlider.value = playerHealth;
            anime.SetBool("damaged", true);
            hitting.Play ();
        }
        if (collider.gameObject.tag == "P2punch2")
        {
            playerHealth -= 3;
            healthSlider.value = playerHealth;
            anime.SetBool("damaged", true);
            hitting.Play ();
        }
        if (collider.gameObject.tag == "P2Uppercut")
        {
            playerHealth -= 15;
            healthSlider.value = playerHealth;
            anime.SetBool("damaged", true);
            hitting.Play ();
        }
        if (collider.gameObject.tag == "P2kick")
        {
            playerHealth -= 10;
            healthSlider.value = playerHealth;
            anime.SetBool("damaged", true);
            hitting.Play ();
        }
        if (collider.gameObject.tag == "P2throwChicken")
        {
            playerHealth -= 2;
            healthSlider.value = playerHealth;
			hitting.Play ();
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "P2punch1")
        {
            anime.SetBool("damaged", false);
        }
        if (collider.gameObject.tag == "P2punch2")
        {
            anime.SetBool("damaged", false);
        }
        if (collider.gameObject.tag == "P2Uppercut")
        {
            anime.SetBool("damaged", false);
        }
        if (collider.gameObject.tag == "P2kick")
        {
            anime.SetBool("damaged", false);
        }
        if (collider.gameObject.tag == "P2throwChicken")
        {
            anime.SetBool("damaged", false);
        }
    }

}
