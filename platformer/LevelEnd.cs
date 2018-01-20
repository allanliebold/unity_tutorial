using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelEnd : MonoBehaviour {

  public string levelName;

  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player") {
      SceneManager.LoadScene(levelName);
    }
  }
}
