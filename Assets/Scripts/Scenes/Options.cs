using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes {

	public class Options : MonoBehaviour {
		
		public Slider VolumeSlider;
		public Slider DifficultySlider;

		private MusicManager _musicManager;

		public void SaveOptions() {
			OptionsManager.Difficulty = (int) DifficultySlider.value;
			OptionsManager.MasterVolume = VolumeSlider.value;
		}

		public void Start() {
			InitializeReferences();
			LoadOptions();
		}

		public void UpdateMasterVolume() {
			if (_musicManager) {
				_musicManager.GetComponent<AudioSource>()
					.volume = VolumeSlider.value;
			}
		}

		private void InitializeReferences() {
			_musicManager = FindObjectOfType<MusicManager>();
		}

		private void LoadOptions() {
			VolumeSlider.value = OptionsManager.MasterVolume;
			DifficultySlider.value = OptionsManager.Difficulty;
		}

		public void RestoreDefaults() {
			OptionsManager.RestoreDefaults();
			LoadOptions();
		}

	}

}
