using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Transitions {

  public class FadeOut : MonoBehaviour {

    public float Duration = 0.5f;

    private readonly Color _endColor = Color.black;
    private float _alphaStep;
    private Image _image;

    public void Start() {
      _image = GetComponent<Image>();
      _image.color = Color.clear;
      _alphaStep = _endColor.a / Duration;
    }

    public void Update() {
      if (_image.color.a < _endColor.a) {
        var color = _image.color;
        color.a += Time.deltaTime * _alphaStep;
        _image.color = color;
      }
    }

  }

}