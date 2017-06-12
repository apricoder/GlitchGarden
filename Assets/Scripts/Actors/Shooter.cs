using UnityEngine;

namespace Actors {

  public class Shooter : MonoBehaviour {

    public GameObject Gun;
    public GameObject Projectile;
    public GameObject ProjectilesParent;

    public void Shoot() {
      Instantiate(Projectile, Gun.transform.position, Quaternion.identity, ProjectilesParent.transform);
    }
    
  }
}