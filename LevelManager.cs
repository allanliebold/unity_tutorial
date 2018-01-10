using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

  public float respawnTime;
  public PlayerController thePlayer;

  void Start() {
    thePlayer = FindObjectOfType<PlayerController>();
  }

  public void Respawn() {
    thePlayer.gameObject.SetActive(false);
    thePlayer.transform.position = thePlayer.respawnPosition;
    thePlayer.gameObject.SetActive(true);
  }
}
