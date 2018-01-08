using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  private Rigidbody2D myRigidbody;

  public float moveSpeed;
  public float jumpHeight;

  public Transform groundCheck;
  public float groundRadius;
  public LayerMask groundLayer;
  public bool isGrounded;

  void Start () {
    myRigidbody = GetComponent<Rigidbody2D>();
  }

  void Update () {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

    if(Input.GetAxisRaw("Horizontal") > 0f) {
      myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
    }
    else if(Input.GetAxisRaw("Horizontal") < 0f) {
      myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
    } else {
      myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
    }

    if(Input.GetButtonDown("Jump") && isGrounded){
      myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpHeight, 0f);
    }
  }
}
