using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public float moveSpeed;
  private Rigidbody2D myRigidbody;

  void Start () {
    myRigidbody = GetComponent<Rigidbody2D>();
  }

  void Update () {

  }
}
