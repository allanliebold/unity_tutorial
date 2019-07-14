using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public Rigidbody2D playerBody;
  public float moveSpeed, jumpHeight;
  public Transform groundCheck;
  public float groundCheckRadius;
  public LayerMask ground, ladder;
  public bool isGrounded;
  public bool isClimbing;
  private Animator animator;
  
  void Start() {
    playerBody = GetComponent<Rigidbody2D> ();
    animator = GetComponent<Animator> ();
  }
  
  void Update() {
    Grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
    isClimbing = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ladder);
    
    if(Input.GetAxisRaw("Horizontal") > 0f) {
      playerBody.velocity = new Vector3(moveSpeed, playerBody.velocity.y, 0f);
    } else if(Input.GetAxisRaw('Horizontal') < 0f) {
      playerBody.velocity = new Vector3(-moveSpeed, playerBody.velocity.y, 0f);
    } else {
      playerBody.velocity = new Vector3(0f, playerBody.velocity.y, 0f);
    }
    
    if(Input.GetButtonDown("Jump") && isGrounded) {
      playerBody.velocity = new Vector3(playerBody.velocity.x, jumpHeight, 0f);  
    }
    
    animator.SetFloat("Speed", Mathf.Abs(playerBody.velocity.x));
    animator.SetBool("Grounded", isGrounded);
  }
}
