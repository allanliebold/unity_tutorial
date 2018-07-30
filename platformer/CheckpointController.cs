using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {
  private SpriteRenderer spriteRenderer;
  public Sprite flagClosed, flagOpen;

  void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player") {
      spriteRenderer.sprite = flagOpen;
    }
  }
}
