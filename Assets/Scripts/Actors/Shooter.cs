using UnityEngine;

namespace Actors
{
    public class Shooter : MonoBehaviour
    {
        private GameObject _projectilesParent;

        public GameObject Gun;
        public GameObject Projectile;

        private void Start()
        {
            _projectilesParent = GameObject.Find("Projectiles");
            if (!_projectilesParent)
            {
                _projectilesParent = new GameObject("Projectiles");
            }
        }

        public void Shoot()
        {
            Instantiate(Projectile, Gun.transform.position, Quaternion.identity, _projectilesParent.transform);
        }
    }
}