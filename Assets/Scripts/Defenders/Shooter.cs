using UnityEngine;

namespace Defenders
{
    public class Shooter : MonoBehaviour
    {
        private GameObject _parent;

        public GameObject Gun;
        public GameObject Projectile;

        private void Start()
        {
            _parent = GameObject.Find("Projectiles");
            if (!_parent)
            {
                _parent = new GameObject("Projectiles");
            }
        }

        public void Shoot()
        {
            Instantiate(Projectile, Gun.transform.position, Quaternion.identity, _parent.transform);
        }
    }
}