using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

  public float moveSpeed;
  private bool canMove;
  
  private Rigidbody2D enemyBody;
  
  void Start() {
    enemyBody = GetComponent<Rigidbody2D>();
  }
  
  void Update() {
    if(canMove) {
      enemyBody.velocity = new Vector3(-moveSpeed, enemyBody.velocity.y, 0f);
    }
  }
  
  void OnBecameVisible() {
    canMove = true;
  }
  
  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Boundary") {
      Destroy(gameObject);
    }
  }
}
