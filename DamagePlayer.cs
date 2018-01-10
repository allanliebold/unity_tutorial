using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

  private LevelManager levelManager;

  void Start() {
    levelManager = FindObjectOfType<LevelManager>();
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player") {
      levelManager.Respawn();
    }
  }
  
}
