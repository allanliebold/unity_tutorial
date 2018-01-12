using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

  private Vector3 startPosition, startLocalScale;
  private Quaternion startRotation;
  private Rigidbody2D myRigidbody;

  void Start() {
    startPosition = transform.position;
    startRotation = transform.rotation;
    startLocalScale = transform.localScale;

    if(GetComponent<Rigidbody2D>() != null) {
      myRigidbody = GetComponent<Rigidbody2D>();
    }
  }

  public void ResetObject() {
    transform.position = startPosition;
    transform.rotation = startRotation;
    transform.localScale = startLocalScale;

    if(myRigidbody != null) {
      myRigidbody.velocity = Vector3.zero;
    }
  }
}
