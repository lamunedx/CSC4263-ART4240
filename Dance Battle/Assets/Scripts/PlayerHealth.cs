using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float playerHealth = 100f;
	protected float damage = 5f;
	public GameObject otherPlayersHP;

	protected void decreaseHealth() {
		playerHealth -= damage;
		float calc_Health = playerHealth / 50f;
		setHealthBar (calc_Health);

	}


	public void setHealthBar(float myHealth) {
    otherPlayersHP.transform.localScale = new Vector3 (myHealth, otherPlayersHP.transform.localScale.y, otherPlayersHP.transform.localScale.z);
	}

  private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "player2")
        {
            decreaseHealth();
        }

        else if (other.gameObject.tag == "player1")
        {
            decreaseHealth();
        }
        
    }
}
