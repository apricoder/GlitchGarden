using UnityEngine;
using UnityEngine.UI;

namespace Common {
	
	public class GameTimer : MonoBehaviour {

		[Range(0.0f, 50.0f)]
		public float Speed;

		public GameObject WinText;
		
		private Slider _slider;
		private SceneManager _sceneManager;
		private GameObject _playScene;
		private bool _won;

		private void Start() {
			_slider = GetComponent<Slider>();
			_playScene = GameObject.Find("Play Scene");
			_sceneManager = FindObjectOfType<SceneManager>();
		}

		private void Update () {
			if (_slider.value >= 100.0f && !_won) {
				FindObjectOfType<LoseCollider>().gameObject.SetActive(false);
				Instantiate(WinText, _playScene.transform);
				Invoke(Name.OfMethod(ShowNextLevel), 5.0f);
				_won = true;
			} else {
				_slider.value += Time.deltaTime * Speed;
			}
		}

		private void ShowNextLevel() {
			_sceneManager.LoadNextScene();
		}
	}
}
