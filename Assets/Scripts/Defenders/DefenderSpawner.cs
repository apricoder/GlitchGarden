using Common;
using UnityEngine;

namespace Defenders {
  public class DefenderSpawner : MonoBehaviour {

    public Camera Camera;

    private GameObject _parent;
    private StarController _starController;

    private void Start() {
      _starController = FindObjectOfType<StarController>();
      _parent = GameObject.Find("Defenders");
      if (!_parent) {
        _parent = new GameObject("Defenders");
      }
    }

    private void OnMouseDown() {
      var position = WorldGridPosition(Input.mousePosition);
      var activeButton = DefenderSelectButton.SelectedDefender;
      if (!activeButton) return;
      var defenderGo = activeButton.GetComponent<DefenderSelectButton>().DefenderPrefab;
      var defender = defenderGo.GetComponent<Defender>();
      if (_starController.SpendStars(defender.StarPrice) == StarController.Status.Success) {
        Instantiate(defenderGo, position, Quaternion.identity, _parent.transform);
      } else {
        Debug.LogError("Not enough stars");
      }
    }

    private Vector3 WorldGridPosition(Vector3 mousePosition) {
      Vector2 worldPoint = Camera.ScreenToWorldPoint(mousePosition);
      worldPoint = new Vector2(
        Mathf.RoundToInt(worldPoint.x),
        Mathf.RoundToInt(worldPoint.y)
      );
      return worldPoint;
    }

  }
}