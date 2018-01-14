using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

  public float respawnTime;
  public PlayerController thePlayer;

  public Text coinText, livesText;
  public int coinCount, coinBonusAmount;
  private int coinBonusCounter;
  public AudioSource pickupSound;

  public int currentLives, startingLives;

  public Image heart1, heart2, heart3;
  public Sprite heartFull, heartHalf, heartEmpty;
  public int maxHealth, healthCount;
  private bool respawning;

  public GameObject gameOverScreen;
  public AudioSource levelMusic, gameOverMusic;

  public Reset[] resetObjects;

  public bool invincible;
  public GameObject deathAnimation;

  void Start() {
    thePlayer = FindObjectOfType<PlayerController>();

    coinCount = 0;
    coinText.text = "Coins:" + coinCount;
    coinBonusCounter = coinBonusAmount;

    currentLives = startingLives;
    livesText.text = "x " + currentLives;

    healthCount = maxHealth;

    resetObjects = FindObjectsOfType<Reset>();
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

    if(coinCount > coinBonusCounter) {
      AddLives(1);
      coinBonusCounter += coinBonusAmount;
    }
  }

  public void HealthDown(int damageAmount) {
    if(!invincible) {
      healthCount -= damageAmount;
      HeartDisplay();

      thePlayer.Knockback();
      thePlayer.hurtSound.Play();
    }
  }

  public void HealthUp(int healthAmount) {
    healthCount += healthAmount;
    if(healthCount > maxHealth)
      healthCount = maxHealth;
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

  public void AddLives(int livesToAdd) {
    currentLives += livesToAdd;
    livesText.text = "x " + currentLives;
  }

  public void Respawn() {
    heart3.sprite = heart2.sprite = heart1.sprite = heartEmpty;
    currentLives -= 1;
    livesText.text = "x " + currentLives;

    if(currentLives > 0) {
      StartCoroutine("RespawnCo");
    } else {
      thePlayer.gameObject.SetActive(false);
      gameOverScreen.SetActive(true);
      levelMusic.Stop();
      gameOverMusic.Play();
    }
  }

  public IEnumerator RespawnCo() {
    thePlayer.gameObject.SetActive(false);
    Instantiate(deathAnimation, thePlayer.transform.position, thePlayer.transform.rotation);

    yield return new WaitForSeconds(respawnTime);
    healthCount = maxHealth;
    HeartDisplay();

    thePlayer.transform.parent = null;
    thePlayer.onPlatform = false;
    thePlayer.transform.position = thePlayer.respawnPosition;
    thePlayer.gameObject.SetActive(true);

    respawning = false;

    for(int i = 0; i < resetObjects.Length; i++) {
      resetObjects[i].gameObject.SetActive(true);
      resetObjects[i].ResetObject();
    }
  }
}
