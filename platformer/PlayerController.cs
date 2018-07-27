using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public float moveSpeed;
  public Rigidbody2D playerBody;
  
  void Start() {
    playerBody = GetComponent<Rigidbody2D>();
  }
  
  void Update() {
    if(Input.GetAxisRaw('Horizontal') > 0f) {
      playerBody.velocity = new Vector3(moveSpeed, playerBody.velocity.y, 0f);
    } else if(Input.GetAxisRaw('Horizontal') < 0f) {
      playerBody.velocity = new Vector3(-moveSpeed, playerBody.velocity.y, 0f);
    } else {
      
    }
  }
}
