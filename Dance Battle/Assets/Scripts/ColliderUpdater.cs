using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderUpdater : MonoBehaviour {

  public bool iStrigger;
  private SpriteRenderer sprite;
  private List<Sprite> animationContainer;
  private Dictionary<int, PolygonCollider2D> spriteColliders;
  private bool _processing;
  private int _frame;

  public int Frame {
    get {
      return _frame;
    }
    set {
      if (value != _frame) {
        if (value > -1) {
          spriteColliders[_frame].enabled = false;
          _frame = value;
          spriteColliders[_frame].enabled = true;
        }
        else {
          _processing = true;
          StartCoroutine(AddSpriteCollider(sprite.sprite));
        }
      }
    }
  }

  private IEnumerator AddSpriteCollider(Sprite sprite) {
    animationContainer.Add(sprite);
    int index = animationContainer.IndexOf(sprite);
    PolygonCollider2D spriteCollider = gameObject.AddComponent<PolygonCollider2D>();
    spriteCollider.isTrigger = iStrigger;
    spriteColliders.Add(index, spriteCollider);
    yield return new WaitForEndOfFrame();
    Frame = index;
    _processing = false;
  }

  private void OnEnable() {
    spriteColliders[Frame].enabled = true;
  }

  private void OnDisable() {
    spriteColliders[Frame].enabled = false;
  }

  private void Awake() {
    sprite = this.GetComponent<SpriteRenderer>();

    animationContainer = new List<Sprite>();

    spriteColliders = new Dictionary<int, PolygonCollider2D>();

    Frame = animationContainer.IndexOf(sprite.sprite);
  }

  private void LateUpdate() {
    if (!_processing)
      Frame = animationContainer.IndexOf(sprite.sprite);
  }
}
