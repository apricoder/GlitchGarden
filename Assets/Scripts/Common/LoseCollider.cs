using Attackers;
using UnityEngine;

namespace Common {

  public class LoseCollider : MonoBehaviour {

    private SceneManager _sceneManager;

    private void Start() {
      _sceneManager = FindObjectOfType<SceneManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if (other.GetComponent<Attacker>()) {
        _sceneManager.LoadScene("03b Lose");
      }
    }

  }
}