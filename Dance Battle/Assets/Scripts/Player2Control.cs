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
    public Canvas endFight;
    private CapsuleCollider2D[] capColliders;
    public GameObject gameController;
    public Text fightOver;
    public Image player1Wins;
    private bool grounded;
    private bool uc;
	private bool controller = false;
	private AudioSource hitting;
    private AudioSource dying;


    void Awake()
    {
        anime = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();

        attackTime = Time.time;

        capColliders = gameObject.GetComponents<CapsuleCollider2D>();
        grounded = true;
        uc = false;
        string[] joysticks = Input.GetJoystickNames();
        if (joysticks.Length >1)
        {
			if(joysticks[1] != "")
            {
                controller = true;
                Debug.Log(joysticks.Length);
            }
		}
        hitting = GetComponents<AudioSource>()[0];
        dying = GetComponents<AudioSource>()[1];
    }

    void Update()
    {   //uppercut combo
        if (!uc)
        {
            if (((Input.GetButtonDown("A") && Input.GetAxis("LeftJoystickY") > 0) || (Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.UpArrow))) && !anime.GetBool("moving") && Time.time > attackTime + .8 && anime.GetBool("onGround") && !anime.GetBool("uppercut") && !anime.GetBool("blocking"))
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
            anime.SetBool("uppercut", false);
            uppercut.transform.Translate(new Vector3(3.3f, -1.240f, 0));
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
        else if (Input.GetAxis("LeftJoystickY") < 0 || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow) && anime.GetBool("onGround"))
        {
            anime.SetBool("moving", false);
            anime.SetBool("crouching", true);
            capColliders[0].offset = new Vector2(capColliders[0].offset.x, -1f);
            capColliders[2].offset = new Vector2(capColliders[2].offset.x, 0f);
            kick.transform.position = new Vector3(kick.transform.position.x, -8f, 0);
            punch1.transform.position = new Vector3(punch1.transform.position.x, -8f, 0);

        }
        //Jump
        else if ((Input.GetButtonDown("Y") || Input.GetKeyDown(KeyCode.KeypadEnter)) && grounded)
        {
            anime.SetBool("jumping", true);
            rigid.AddForce(Vector2.up * 575f);
        }
        //uncrouch
		else if (((Input.GetAxis("LeftJoystickY") == 0)&& controller) || Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anime.SetBool("crouching", false);
            capColliders[0].offset = new Vector2(capColliders[0].offset.x, .17f);
            capColliders[2].offset = new Vector2(capColliders[2].offset.x, 1.02f);
            kick.transform.position = new Vector3(kick.transform.position.x, 0f, 0);
            punch1.transform.position = new Vector3(punch1.transform.position.x, 0f, 0);
        }
        //stand still
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anime.SetBool("moving", false);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anime.SetBool("moving", false);
        }
        if (((Input.GetAxis("LeftJoystickX") == 0 && controller)) || (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)))
        {
            anime.SetBool("moving", false);;
        }

        // action keys -------------------------------------------------------------
        //punch1
        if ((Input.GetButtonDown("X") || Input.GetKeyDown(KeyCode.J)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .2 && anime.GetBool("onGround") && !anime.GetBool("punching"))
        {
            punch1.SetActive(true);
            anime.SetBool("punching", true);
            punch1.transform.Translate(new Vector3(-3.04f, 0, 0));
            attackTime = Time.time;
        }
        //punch 2
        else if ((Input.GetButtonDown("A") || Input.GetKeyDown(KeyCode.K)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .2 && anime.GetBool("onGround") && !anime.GetBool("punch2"))
        {
            punch2.SetActive(true);
            anime.SetBool("punch2", true);
            punch2.transform.Translate(new Vector3(-2.33f, 0, 0));
            attackTime = Time.time;
        }
        //kick
        else if ((Input.GetButtonDown("B") || Input.GetKeyDown(KeyCode.O)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .35 && anime.GetBool("onGround") && !anime.GetBool("kicking"))
        {
            kick.SetActive(true);
            anime.SetBool("kicking", true);
            //kickCol.enabled = true;
            kick.transform.Translate(new Vector3(-2.06f, 0, 0));
            attackTime = Time.time;
        }
        //block
        else if ((Input.GetButtonDown("RB") || Input.GetButtonDown("LB") || Input.GetKeyDown(KeyCode.L)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && anime.GetBool("onGround"))
        {
            anime.SetBool("blocking", true);
            capColliders[0].enabled = false;
        }
        //stops punch 1 on hold
        if ((Input.GetButton("X") || Input.GetKey(KeyCode.J)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .2 && anime.GetBool("onGround") && anime.GetBool("punching"))
        {
            punch1.transform.Translate(new Vector3(3.04f, 0, 0));
            attackTime = Time.time;
        }
        //stops punch 2 on hold
        if ((Input.GetButton("A") || Input.GetKey(KeyCode.K)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .2 && anime.GetBool("onGround") && anime.GetBool("punch2"))
        {
            anime.SetBool("punch2", false);
            punch2.transform.Translate(new Vector3(2.33f, 0, 0));
            attackTime = Time.time;
        }
        //stops kick 1 on hold
        if ((Input.GetButton("B") || Input.GetKey(KeyCode.O)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && Time.time > attackTime + .35 && anime.GetBool("onGround") && anime.GetBool("kicking"))
        {
            anime.SetBool("kicking", false);
            kick.transform.Translate(new Vector3(2.06f, 0, 0));
            attackTime = Time.time;
        }
        //block on hold
        if ((Input.GetButton("RB") || Input.GetButton("LB") || Input.GetKey(KeyCode.L)) && !anime.GetBool("moving") && !anime.GetBool("damaged") && anime.GetBool("onGround"))
        {
            anime.SetBool("blocking", true);
            capColliders[0].enabled = false;

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
        //Stop kick if released
        if ((Input.GetButtonUp("B") || Input.GetKeyUp(KeyCode.O)) && anime.GetBool("kicking"))
        {
            anime.SetBool("kicking", false);
            kick.transform.Translate(new Vector3(2.06f, 0, 0));
        }
        //stop block on release
        if ((Input.GetButtonUp("RB") || Input.GetButtonUp("LB") || Input.GetKeyUp(KeyCode.L)) && anime.GetBool("blocking"))
        {
            anime.SetBool("blocking", false);
            capColliders[0].enabled = true;

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
            otherPlayer.GetComponent<Animator>().SetBool("blocking", false);
            gameController.GetComponent<fightTime>().enabled = false;
            gameController.GetComponent<fightTime>().StopAllCoroutines();
            endFight.enabled = true;
            player1Wins.enabled = true;
            transform.Translate(1f, 0, -1f);
            anime.Play("koed");
            dying.Play();
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

        if (collider.gameObject.tag == "P1punch1")
        {
            playerHealth -= 5;
            healthSlider.value = playerHealth;
			anime.Play ("Damaged");
            Debug.Log("player 1 punched me");
			hitting.Play ();
        }
        if (collider.gameObject.tag == "P1punch2")
        {
            playerHealth -= 3;
            healthSlider.value = playerHealth;
            anime.SetBool("damaged", true);
            hitting.Play ();
        }
        if (collider.gameObject.tag == "P1Uppercut")
        {
            playerHealth -= 15;
            healthSlider.value = playerHealth;
            anime.SetBool("damaged", true);
            hitting.Play ();
        }
        if (collider.gameObject.tag == "P1kick")
        {
            playerHealth -= 10;
            healthSlider.value = playerHealth;
            anime.SetBool("damaged", true);
            hitting.Play ();
        }
        if (collider.gameObject.tag == "P1throwChicken")
        {
            playerHealth -= 2;
            healthSlider.value = playerHealth;
			hitting.Play ();
        }

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "P1punch1")
        {
            anime.SetBool("damaged", false);
        }
        if (collider.gameObject.tag == "P1punch2")
        {
            anime.SetBool("damaged", false);
        }
        if (collider.gameObject.tag == "P1Uppercut")
        {
            anime.SetBool("damaged", false);
        }
        if (collider.gameObject.tag == "P1kick")
        {
            anime.SetBool("damaged", false);
        }
        if (collider.gameObject.tag == "P1throwChicken")
        {
            anime.SetBool("damaged", false);
        }
    }
}
