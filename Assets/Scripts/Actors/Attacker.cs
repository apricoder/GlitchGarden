using UnityEngine;

namespace Actors {

  public class Attacker : MonoBehaviour {

    [Range(-2.0f, 5.0f)]
    public float Speed;

    private void Update() {
      transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
      Debug.Log(gameObject.name + " touched " + other.gameObject.name);
    }

  }
}