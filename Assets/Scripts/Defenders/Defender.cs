using Common;
using UnityEngine;

namespace Defenders {
  public class Defender : MonoBehaviour {

    public int StarPrice = 100;
    
    private StarController _starController;

    private void Start() {
      _starController = FindObjectOfType<StarController>();
    }

    public void Die() {
      Destroy(gameObject);
    }

    public void AddStars(int amount) {
      _starController.AddStars(amount);
    }

  }
}