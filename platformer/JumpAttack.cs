using UnityEngine;
using System.Collections;

public class JumpAttack : MonoBehaviour {

  private Rigidbody2D playerBody;
  public float bounceAmount;
  public GameObject enemyDeath;

  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Enemy") {
      other.SetActive(false);
      Instantiate(enemyDeath, other.transform.position, other.transform.rotation);

      playerBody.velocity = new Vector3(playerBody.velocity.x, bounceAmount, 0f);
    }
  }
}
