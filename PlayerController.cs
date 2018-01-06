using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public float moveSpeed;
  private Rigidbody2D myRigidbody;

  void Start () {
    myRigidbody = GetComponent<Rigidbody2D>();
  }

  void Update () {
    if(Input.GetAxisRaw("Horizontal") > 0f) {
      myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
    }
    else if(Input.GetAxisRaw("Horizontal") < 0f) {
      myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
    } else {
      myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
    }
  }
}
