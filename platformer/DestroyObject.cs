using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
  public float lifeTime;

  void Update() {
    lifeTime = lifeTime - Time.deltaTime;

    if(lifeTime <= 0f) {
      Destroy(gameObject);
    }
  }
}
