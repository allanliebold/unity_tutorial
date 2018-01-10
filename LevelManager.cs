using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

  public float respawnTime;
  public PlayerController thePlayer;

  public GameObject deathAnimation;

  void Start() {
    thePlayer = FindObjectOfType<PlayerController>();
  }

  public void Respawn() {
    StartCoroutine("RespawnCo");
  }

  public IEnumerator RespawnCo() {
    thePlayer.gameObject.SetActive(false);
    Instantiate(deathAnimation, thePlayer.transform.position, thePlayer.transform.rotation);

    yield return new WaitForSeconds(respawnTime);
    thePlayer.transform.parent = null;
    thePlayer.transform.position = thePlayer.respawnPosition;
    thePlayer.gameObject.SetActive(true);
  }
}
