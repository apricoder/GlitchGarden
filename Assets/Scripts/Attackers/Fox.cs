using Defenders;
using UnityEngine;

namespace Attackers
{
    [RequireComponent(typeof(Attacker))]
    public class Fox : MonoBehaviour
    {
        private Animator _animator;
        private Attacker _attacker;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _attacker = GetComponent<Attacker>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var target = other.gameObject;

            if (!target.GetComponent<Defender>())
            {
                return;
            }

            if (target.GetComponent<GraveStone>())
            {
                Debug.Log(name + " should now jump!");
                _animator.SetTrigger("jump");
            }
            else
            {
                _attacker.Attack(target);
            }
        }
    }
}