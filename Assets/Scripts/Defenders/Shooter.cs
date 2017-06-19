using System.Linq;
using Attackers;
using UnityEngine;

namespace Defenders {

  [RequireComponent(typeof(Animator))]
  public class Shooter : MonoBehaviour {

    public GameObject Gun;
    public GameObject Projectile;

    private GameObject _parent;
    private Animator _animator;
    public AttackerSpawner _myLaneAttackerSpawner;

    private void Start() {
      _animator = GetComponent<Animator>();
      _parent = GameObject.Find("Projectiles");
      if (!_parent) {
        _parent = new GameObject("Projectiles");
      }
      
      SetMyLaneSpawner();
    }

    private void Update() {
      _animator.SetBool("attacking", attackerAheadInLine());
    }

    private bool attackerAheadInLine() {
      return _myLaneAttackerSpawner.gameObject.transform.Cast<Transform>()
        .Any(attacker => attacker.position.x > transform.position.x);
    }

    private void SetMyLaneSpawner() {
      var spawners = FindObjectsOfType<AttackerSpawner>();
      foreach (var spawner in spawners) {
        if ((int) spawner.gameObject.transform.position.y == (int) gameObject.transform.position.y) {
          _myLaneAttackerSpawner = spawner;
        }
      }
    }

    public void Shoot() {
      Instantiate(Projectile, Gun.transform.position, Quaternion.identity, _parent.transform);
    }

  }
}