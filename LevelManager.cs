using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

  public float respawnTime;
  public PlayerController thePlayer;

  public int coinCount;
  public Text coinText;

  public Image heart1, heart2, heart3;
  public Sprite heartFull, heartHalf, heartEmpty;
  public int maxHealth, healthCount;
  private bool respawning;
  
  public GameObject deathAnimation;

  void Start() {
    thePlayer = FindObjectOfType<PlayerController>();
    
    coinCount = 0;
    coinText.text = "Coins:" + coinCount;
    
    healthCount = maxHealth;
  }
  
  void Update() {
    if(healthCount <= 0 && !respawning) {
      Respawn();
      respawning = true;
    }
  }

  public void CoinPickup(int coinValue) {
    coinCount += coinValue;
    coinText.text = "Coins: " + coinCount;
  }
  
  public void HealthDown(int damageAmount) {
    healthCount -= damageAmount;
    HeartDisplay();
  }
  
  	public void HeartDisplay() {
		switch(healthCount) {
		case 6:
			heart3.sprite = heart2.sprite = heart1.sprite = heartFull;
			return;
		case 5:
			heart3.sprite = heartHalf;
			heart2.sprite = heartFull;
			heart1.sprite = heartFull;
			return;
		case 4:
			heart3.sprite = heartEmpty;
			heart2.sprite = heartFull;
			heart1.sprite = heartFull;
			return;
		case 3:
			heart3.sprite = heartEmpty;
			heart2.sprite = heartHalf;
			heart1.sprite = heartFull;
			return;
		case 2:
			heart3.sprite = heartEmpty;
			heart2.sprite = heartEmpty;
			heart1.sprite = heartFull;
			return;
		case 1:
			heart3.sprite = heartEmpty;
			heart2.sprite = heartEmpty;
			heart1.sprite = heartHalf;
			return;
		}
	}

  public void Respawn() {
    heart3.sprite = heart2.sprite = heart1.sprite = heartEmpty;
    StartCoroutine("RespawnCo");
  }

  public IEnumerator RespawnCo() {
    thePlayer.gameObject.SetActive(false);
    Instantiate(deathAnimation, thePlayer.transform.position, thePlayer.transform.rotation);

    yield return new WaitForSeconds(respawnTime);
    healthCount = maxHealth;
    HeartDisplay();
    
    thePlayer.transform.parent = null;
    thePlayer.transform.position = thePlayer.respawnPosition;
    thePlayer.gameObject.SetActive(true);
    
    respawning = false;
  }
}
