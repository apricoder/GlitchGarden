using UnityEngine;
using UnityEngine.UI;

namespace Defenders {
  public class DefenderSelectButton : MonoBehaviour {

    public static GameObject SelectedDefender;
    public GameObject DefenderPrefab;
    private Text _priceText;

    private void Start() {
      _priceText = GetComponentInChildren<Text>();
      _priceText.text = DefenderPrefab.GetComponent<Defender>().StarPrice.ToString();
    }

    private void OnMouseDown() {
      if (SelectedDefender) {
        SetSelectedDefenderSpriteColor(Color.black);
      }

      SelectedDefender = gameObject;
      SetSelectedDefenderSpriteColor(Color.white);
    }

    private static void SetSelectedDefenderSpriteColor(Color color) {
      SelectedDefender.transform
        .GetComponentInChildren<SpriteRenderer>()
        .color = color;
    }

  }
}