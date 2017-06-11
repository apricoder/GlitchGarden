using UnityEngine;

namespace Common {

    public class SceneManager : MonoBehaviour {
        
        public void LoadScene(string levelName) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);        
        }

        public void LoadNextScene() {
            var activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            var nextSceneIndex = activeScene.buildIndex + 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
        }

    }

}