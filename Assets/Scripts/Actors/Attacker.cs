using UnityEngine;

namespace Actors {

  [RequireComponent(typeof(Rigidbody2D))]
  public class Attacker : MonoBehaviour {

    [Range(-2.0f, 5.0f)]
    public float Speed;

    private float _currentSpeed;
    private GameObject _currentTarget;
    private Animator _animator;

    private void Start() {
      _currentSpeed = Speed;
      _animator = GetComponent<Animator>();
    }

    private void Update() {
      transform.Translate(Vector3.left * _currentSpeed * Time.deltaTime);
    }

    public void SetSpeed(float speed) {
      _currentSpeed = speed;
    }

    public void ResetDefaultSpeed() {
      _currentSpeed = Speed;
    }

    public void StrikeCurrentTarget(float damage) {
      // Debug.Log(name + " hit target with damage " + damage);
    }

    public void Attack(GameObject target) {
      _currentTarget = target;
      Debug.Log(gameObject.name + " attacking " + target.name);
      _animator.SetBool("attacking", true);
    }

  }
}