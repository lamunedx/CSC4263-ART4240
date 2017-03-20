using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideOffTrigger : MonoBehaviour {
  private Rigidbody2D player;
  private Rigidbody2D otherPlayer;

  private void OnTriggerStay2D(Collider2D collision) {
    player = GetComponentInParent<Rigidbody2D>();
    if (player.transform.localScale.x == -1) {
      otherPlayer = collision.GetComponent<Rigidbody2D>();
      otherPlayer.transform.Translate(Vector2.right * 3f * Time.deltaTime);
    }
    else if (player.transform.localScale.x == 1) {
      otherPlayer = collision.GetComponent<Rigidbody2D>();
      otherPlayer.transform.Translate(Vector2.left * 3f * Time.deltaTime);
    }
  }
}
