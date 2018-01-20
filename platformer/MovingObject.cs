using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

  public GameObject movingObject;

  public Transform startPoint;
  public Transform endPoint;
  public float moveSpeed;
  private Vector3 currentTarget;

  void Start() {
    currentTarget = endPoint.position;
  }

  void Update() {
    movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, currentTarget, moveSpeed * Time.deltaTime);

    if(movingObject.transform.position == endPoint.position) {
      currentTarget = startPoint.position;
    }

    if(movingObject.transform.position == startPoint.position) {
      currentTarget = endPoint.position;
    }
  }
  
}
