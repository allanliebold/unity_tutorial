using UnityEngine;
using System.Collections;

public class PatrolEnemyController : MonoBehaviour {

  private Rigidbody2D enemyBody;

  public Transform leftPoint, rightPoint;
  public float moveSpeed;
  public bool movingRight;

  void Start() {
    enemyBody = GetComponent<Rigidbody2D>();
  }

  void Update() {
    if(movingRight && transform.position.x > rightPoint.position.x) {
      movingRight = false;
    }

    if(!movingRight && transform.position.x < leftPoint.position.x) {
      movingRight = true;
    }

    if(movingRight) {
      enemyBody.velocity = new Vector3(moveSpeed, enemyBody.velocity.y, 0f);
    } else {
      enemyBody.velocity = new Vector3(-moveSpeed, enemyBody.velocity.y, 0f);
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Boundary") {
      Destroy(gameObject.transform.parent.gameObject);
    }
  }

}
