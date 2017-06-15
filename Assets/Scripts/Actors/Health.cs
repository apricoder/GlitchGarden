using UnityEngine;

namespace Actors
{
    public class Health : MonoBehaviour
    {
        [Range(0.0f, 300.0f)] public float Value;
    }
}