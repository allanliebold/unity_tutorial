using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

  public float respawnTime;
  public PlayerController thePlayer;

  public int coinCount;
  public Text coinText;

  public GameObject deathAnimation;

  void Start() {
    thePlayer = FindObjectOfType<PlayerController>();
    coinCount = 0;
    coinText.text = "Coins:" + coinCount;
  }

  public void CoinPickup(int coinValue) {
    coinCount += coinValue;
    coinText.text = "Coins: " + coinCount;
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
