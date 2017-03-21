using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float playerHealth = 100f;
	public float cur_Health = 0f;
	protected float damage;
	public GameObject healthBar;
	// Use this for initialization
	void Start () {
	//	player1HealthBar = GameObject.FindWithTag ("p1Health");
	//	player2HealthBar = GameObject.FindWithTag ("p2Health");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void decreaseHealth()
	{
		playerHealth -= damage;
		float calc_Health = playerHealth / 100f;
		setHealthBar (calc_Health);

	}


	public void setHealthBar(float myHealth)
	{
			healthBar.transform.localScale = new Vector3 (myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
