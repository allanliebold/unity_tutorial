using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  private Rigidbody2D myRigidbody;
  public LevelManager levelManager;

  // Movement
  public float moveSpeed;
  private float activeMoveSpeed;
  public float jumpHeight;
  public GameObject feet;

  // Ground Check
  public Transform groundCheck; // a transform is any object in that has a position in the game (x, y, z)
  public float groundRadius;
  public LayerMask groundLayer;
  public bool isGrounded;
    // Platform Check
  public bool onPlatform;
  public float onPlatformSpeed;

  // Knockback
  public float knockbackSide, knockbackUp, knockbackDuration;
  private float knockbackCounter;
    // Invincibility
  public float invincibilityDuration;
  private float invincibilityCounter;

  public Vector3 respawnPosition;

  private Animator playerAnimator;
  public AudioSource jumpSound, hurtSound;

  void Start () {
    myRigidbody = GetComponent<Rigidbody2D>();
    myAnimator = GetComponent<Animator>();
    respawnPosition = transform.position;
    levelManager = FindObjectOfType<LevelManager>();
    activeMoveSpeed = moveSpeed;
  }

  void Update () {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

    if(knockbackCounter >= 0){
      if(onPlatform) {
        activeMoveSpeed = moveSpeed * onPlatformSpeed;
      } else {
        activeMoveSpeed = moveSpeed;
      }

      if(Input.GetAxisRaw("Horizontal") > 0f) {
        myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f);
        transform.localScale = new Vector3(1f, 1f, 1f);
      }
      else if(Input.GetAxisRaw("Horizontal") < 0f) {
        myRigidbody.velocity = new Vector3(-activeMoveSpeed, myRigidbody.velocity.y, 0f);
        transform.localScale = new Vector3(-1f, 1f, 1f);
      } else {
        myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
      }

      if(Input.GetButtonDown("Jump") && isGrounded){
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpHeight, 0f);
        jumpSound.Play();
      }
    }

    if(knockbackCounter > 0) {
      knockbackCounter -= Time.deltaTime;

      if(transform.localScale.x > 0){
        myRigidbody.velocity = new Vector3(-knockbackSide, knockbackUp, 0f);
      } else {
        myRigidbody.velocity = new Vector3(knockbackSide, knockbackUp, 0f);
      }
    }

    if(invincibilityCounter > 0) {
      invincibilityCounter -= Time.deltaTime;
    }

    if(invincibilityCounter <= 0) {
      levelManager.invincible = false;
    }

    playerAnimator.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
    playerAnimator.SetBool("Grounded", isGrounded);
    if(myRigidbody.velocity.y < 0) {
      feet.SetActive(true);
    } else {
      feet.SetActive(false);
    }
  }

  public void Knockback(){
    knockbackCounter = knockbackDuration;
    invincibilityCounter = invincibilityDuration;

    levelManager.invincible = true;
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Boundary") {
      levelManager.Respawn();
    }

    if (other.tag == "Checkpoint") {
      respawnPosition = other.transform.position;
    }
  }

  void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.tag == "Platform") {
      onPlatform = true;
      transform.parent = other.transform;
    }
  }

  void OnCollisionExit2D(Collision2D other) {
    if(other.gameObject.tag == "Platform") {
      onPlatform = false; 
      transform.parent = null;
    }
  }
}
