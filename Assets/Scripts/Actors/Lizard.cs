using UnityEngine;

namespace Actors
{
    [RequireComponent(typeof(Attacker))]
    public class Lizard : MonoBehaviour
    {
        private Attacker _attacker;

        private void Start()
        {
            _attacker = GetComponent<Attacker>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var target = other.gameObject;

            if (!target.GetComponent<Defender>())
            {
                return;
            }

            _attacker.Attack(target);
        }
    }
}