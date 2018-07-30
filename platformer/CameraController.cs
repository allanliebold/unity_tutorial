using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
  public GameObject target;
  public float viewAhead;
  public float cameraSpeed;

  private Vector3 targetPosition;

  void Update() {
    targetPosition = new Vector3(target.tranform.position.x, tranform.position.y, transform.position.z);

    if(target.transform.localScale.x > 0f) {
      targetPosition = new Vector3(targetPosition.x + viewAhead, targetPosition.y, targetPosition.z);
    } else {
      targetPosition = new Vector3(targetPosition.x - viewAhead, targetPosition.y, targetPosition.z);
    }

    transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
  }
}
