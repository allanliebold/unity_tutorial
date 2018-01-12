using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  private Rigidbody2D myRigidbody;
  public LevelManager levelManager;

  public float moveSpeed;
  public float jumpHeight;
  public GameObject feet;

  public Transform groundCheck;
  public float groundRadius;
  public LayerMask groundLayer;
  public bool isGrounded;

  public Vector3 respawnPosition;

  private Animator playerAnimator;

  void Start () {
    myRigidbody = GetComponent<Rigidbody2D>();
    myAnimator = GetComponent<Animator>();
    respawnPosition = transform.position;
    levelManager = FindObjectOfType<LevelManager>();
  }

  void Update () {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

    if(Input.GetAxisRaw("Horizontal") > 0f) {
      myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
      transform.localScale = new Vector3(1f, 1f, 1f);
    }
    else if(Input.GetAxisRaw("Horizontal") < 0f) {
      myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
      transform.localScale = new Vector3(-1f, 1f, 1f);
    } else {
      myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
    }

    if(Input.GetButtonDown("Jump") && isGrounded){
      myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpHeight, 0f);
    }

    playerAnimator.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
    playerAnimator.SetBool("Grounded", isGrounded);

    if(myRigidbody.velocity.y < 0) {
      feet.SetActive(true);
    } else {
      feet.SetActive(false);
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Boundary") {
      levelManager.Respawn();
    }

    if (other.tag == "Checkpoint") {
      respawnPosition = other.transform.position;
    }
  }
}
