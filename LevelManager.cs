using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

  public float respawnTime;
  public PlayerController thePlayer;

  void Start() {
    thePlayer = FindObjectOfType<PlayerController>();
  }

  public void Respawn() {
    StartCoroutine("RespawnCo");
  }

  public IEnumerator RespawnCo() {
    thePlayer.gameObject.SetActive(false);

    yield return new WaitForSeconds(respawnTime);
    thePlayer.transform.position = thePlayer.respawnPosition;
    thePlayer.gameObject.SetActive(true);
  }
}
