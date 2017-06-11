using Common;
using Scenes.Transitions;
using UnityEngine;

namespace Scenes.Base {

    public class Scene : MonoBehaviour {

        public GameObject FadeInCover;
        public GameObject FadeOutCover;

        protected FadeIn FadeIn;
        protected FadeOut FadeOut;
        protected SceneManager SceneManager;

        private string _nextSceneName;

        public virtual void Start() {
            InitReferences();
            StartFadeIn();
        }

        protected virtual void InitReferences() {
            if (!SceneManager) SceneManager = FindObjectOfType<SceneManager>();
            if (!FadeOut && FadeOutCover) FadeOut = FadeOutCover.GetComponent<FadeOut>();
            if (!FadeIn && FadeInCover) FadeIn = FadeInCover.GetComponent<FadeIn>();
        }

        private void StartFadeIn() {
            if (FadeInCover) {
                Instantiate(FadeInCover, transform);
            }
        }

        public void NavigateWithFadeOut(string sceneName) {
            _nextSceneName = sceneName;
            NavigateToNextSceneWithFadeOut();
        }

        public void NavigateToNextSceneWithFadeOut() {
            Invoke(Name.OfMethod(LoadNextScene), FadeOut.Duration);
            StartFadeOut();
        }

        private void LoadNextScene() {
            InitReferences();
            if (_nextSceneName != null) SceneManager.LoadScene(_nextSceneName);
            else SceneManager.LoadNextScene();
        }

        protected void StartFadeOut() {
            Instantiate(FadeOutCover, transform);
        }

    }

}