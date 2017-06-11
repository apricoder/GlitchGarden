using UnityEngine;

namespace Actors {

  public class Defender : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
      // Debug.Log(gameObject.name + " touched " + other.gameObject.name);
    }

  }
}