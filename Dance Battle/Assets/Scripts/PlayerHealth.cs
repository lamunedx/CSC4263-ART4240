using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float max_Health = 100f;
	public float cur_Health = 0f;
	public GameObject healthBar;
	// Use this for initialization
	void Start () {
		cur_Health = max_Health;
		InvokeRepeating ("decreaseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void decreaseHealth()
	{
		cur_Health -= 2f;
		float calc_Health = cur_Health / max_Health;
		setHealthBar (calc_Health);
	}

	public void setHealthBar(float myHealth)
	{
		healthBar.transform.localScale = new Vector3 (myHealth,healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
