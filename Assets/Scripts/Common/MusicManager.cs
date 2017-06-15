using UnityEngine;

namespace Common
{
    public class MusicManager : MonoBehaviour
    {
        public AudioClip[] LevelsMusic;

        private AudioSource _audioSource;

        public void Start()
        {
            InitReferences();
            SetVolumeFromSettings();
            DontDestroyOnLoad(gameObject);
        }

        public void OnLevelChanged(int levelIndex)
        {
            InitReferences();
            var currentMusic = _audioSource.clip;
            var nextMusic = LevelsMusic[levelIndex];
            if (nextMusic && currentMusic != nextMusic)
            {
                _audioSource.Stop();
                _audioSource.clip = LevelsMusic[levelIndex];
                _audioSource.Play();
            }
        }

        private void InitReferences()
        {
            if (!_audioSource) _audioSource = GetComponent<AudioSource>();
        }

        private void SetVolumeFromSettings()
        {
            _audioSource.volume = OptionsManager.MasterVolume;
        }
    }
}