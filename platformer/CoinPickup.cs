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
      gameObject.SetActive(false);
      levelManager.pickupSound.Play();
      levelManager.CoinPickup(coinValue);
    }
  }
}
