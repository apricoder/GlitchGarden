using Common;
using Defenders;
using UnityEngine;

namespace Attackers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Attacker : MonoBehaviour
    {
        [Range(-2.0f, 5.0f)] public float Speed;

        [Range(0.0f, 50.0f)] public float Damage;

        [Range(0.0f, 100.0f)] public float Health;

        [Range(0.0f, 15.0f)] public float AppearingEverySeconds;

        private float _currentSpeed;
        private GameObject _currentTarget;
        private Animator _animator;

        private void Start()
        {
            _currentSpeed = Speed;
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            transform.Translate(Vector3.left * _currentSpeed * Time.deltaTime);
        }

        public void SetSpeed(float speed)
        {
            _currentSpeed = speed;
        }

        public void ResetDefaultSpeed()
        {
            _currentSpeed = Speed;
        }

        public void StrikeCurrentTarget()
        {
            if (!_currentTarget) return;

            var healthLeft = _currentTarget.GetComponent<Health>().Value -= Damage;
            if (healthLeft > 0) return;

            _currentTarget.GetComponent<Defender>().Die();
            _animator.SetBool("attacking", false);
        }

        public void Attack(GameObject target)
        {
            Debug.Log(gameObject.name + " attacking " + target.name);
            _currentTarget = target;
            _animator.SetBool("attacking", true);
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}