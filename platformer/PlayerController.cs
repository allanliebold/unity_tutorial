using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public Rigidbody2D playerBody;
    
  public float moveSpeed; 
  public float jumpHeight;
    
  public Transform groundCheck;
  
  void Start() {
    playerBody = GetComponent<Rigidbody2D>();
  }
  
  void Update() {
    if(Input.GetAxisRaw('Horizontal') > 0f) {
      playerBody.velocity = new Vector3(moveSpeed, playerBody.velocity.y, 0f);
    } else if(Input.GetAxisRaw('Horizontal') < 0f) {
      playerBody.velocity = new Vector3(-moveSpeed, playerBody.velocity.y, 0f);
    } else {
      playerBody.velocity = new Vector3(0f, playerBody.velocity.y, 0f);
    }
    
    if(Input.GetButtonDown('Jump') {
      playerBody.velocity = new Vector3(playerBody.velocity.x, jumpHeight, 0f);  
    }
  }
}
