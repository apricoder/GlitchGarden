using UnityEngine;

namespace Defenders
{
    public class Defender : MonoBehaviour
    {
        public void Die()
        {
            Destroy(gameObject);
        }
    }
}