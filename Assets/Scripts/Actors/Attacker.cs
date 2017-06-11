using UnityEngine;

namespace Actors {

  public class Attacker : MonoBehaviour {

    [Range(-2.0f, 5.0f)]
    public float Speed;

    private float _currentSpeed;

    private void Start() {
      _currentSpeed = Speed;
    }

    private void Update() {
      transform.Translate(Vector3.left * _currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
      Debug.Log(gameObject.name + " touched " + other.gameObject.name);
    }

    public void SetSpeed(float speed) {
      _currentSpeed = speed;
    }

    public void ResetDefaultSpeed() {
      _currentSpeed = Speed;
    }

    public void StrikeCurrentTarget(float damage) {
      Debug.Log(name + " hit target with damage " + damage);
    } 

  }
}