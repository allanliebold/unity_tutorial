using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

  public LevelManager levelManager;
  public int healthAmount;

  void Start(){
    levelManager = FindObjectOfType<LevelManager>();
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player") {
      levelManager.HealthUp(healthAmount);
      gameObject.SetActive(false);
    }
  }
}
