using UnityEngine;

namespace Actors {

  public class Defender : MonoBehaviour {

    public void Die() {
      Destroy(gameObject);
    }

  }
}