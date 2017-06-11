using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Transitions {

  public class FadeIn : MonoBehaviour {

    public static readonly float DefaultDuration = 0.4f;

    public float Duration = DefaultDuration;

    private readonly Color _startColor = Color.black;
    private float _alphaStep;
    private Image _image;

    public void Start() {
      _image = GetComponent<Image>();
      _image.color = _startColor;
      _alphaStep = _startColor.a / Duration;
    }

    public void Update() {
      var color = _image.color;
      color.a -= Time.deltaTime * _alphaStep;
      if (color.a >= 0) _image.color = color;
      else Destroy(gameObject);
    }

  }

}