using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

  public LevelManager levelManager;
  public int coinValue;

  void Start() {
    levelManager = FindObjectOfType<LevelManager>();
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player") {
      Destroy(gameObject);
      levelManager.CoinPickup(coinValue);
    }
  }
}
