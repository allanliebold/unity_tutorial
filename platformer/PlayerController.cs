using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public float moveSpeed;
  public Rigidbody2D playerBody;
  
  void Start() {
    playerBody = GetComponent<Rigidbody2D>();
  }
}
