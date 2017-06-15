using UnityEngine;

namespace Actors
{
    public class Projectile : MonoBehaviour
    {
        [Range(-10.0f, 10.0f)] public float Speed;

        [Range(-1500.0f, 1500.0f)] public float Rotation;

        [Range(0.0f, 100.0f)] public float Damage;

        private GameObject _body;

        private void Start()
        {
            _body = transform.Find("Body").gameObject;
        }

        private void Update()
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            _body.transform.Rotate(0, 0, Rotation * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(gameObject.name + " touched " + other.gameObject.name);
            var attacker = other.GetComponent<Attacker>();
            if (!attacker) return;

            var healthLeft = attacker.GetComponent<Health>().Value -= Damage;
            if (healthLeft < 0) attacker.Die();
            Destroy(gameObject);
        }
    }
}