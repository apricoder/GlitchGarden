using UnityEngine;
using UnityEngine.UI;

namespace Common {

  [RequireComponent(typeof(Text))]
  public class StarController : MonoBehaviour {

    public enum Status {

      Success,
      Failure

    }

    public int Stars = 550;

    private Text _text;

    private void Start() {
      _text = GetComponent<Text>();
      UpdateScore();
    }

    public Status SpendStars(int amount) {
      if (Stars >= amount) {
        Stars -= amount;
        UpdateScore();
        return Status.Success;
      }
      return Status.Failure;
    }

    public void AddStars(int amount) {
      Stars += amount;
      UpdateScore();
    }

    private void UpdateScore() {
      _text.text = Stars.ToString();
    }

  }
}