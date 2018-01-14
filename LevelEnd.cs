using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

  public string levelName;

  void OnCollisionEnter2D(Collider2D other) {
    if(other.tag == "Player") {
      SceneManager.LoadScene(levelName);
    }
  }
}
