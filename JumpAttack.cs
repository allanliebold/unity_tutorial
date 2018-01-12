using UnityEngine;
using System.Collections;

public class JumpAttack : MonoBehaviour {

  public GameObject enemyDeath;

  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Enemy") {
      Destroy(other.gameObject);
      Instantiate(enemyDeath, other.transform.position, other.transform.rotation);
    }
  }
}
