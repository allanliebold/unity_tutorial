using UnityEngine;
using System.Collections;

public class AddLife : MonoBehaviour{
  public int livesToAdd;
  private LevelManager levelManager;

  void Start() {
    levelManager = FindObjectOfType<LevelManager>();
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player") {
      levelManager.pickupSound.Play();
      levelManager.AddLives(livesToAdd);
      gameObject.SetActive(false);
    }
  }
}
