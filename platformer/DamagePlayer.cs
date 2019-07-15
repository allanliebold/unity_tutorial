using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

  private LevelManager levelManager;
  public int damageAmount;
  
  void Start() {
    levelManager = FindObjectOfType<LevelManager>();
  }

}
