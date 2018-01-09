using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

  public GameObject target;

  void Update() {
    transform.position = new Vector3(target.tranform.position.x, tranform.position.y, transform.position.z);
  }
}
