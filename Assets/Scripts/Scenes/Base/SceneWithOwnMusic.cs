using Common;

namespace Scenes.Base {
  public class SceneWithOwnMusic : Scene {

    protected MusicManager MusicManager;

    public override void Start() {
      base.Start();
      PlayMyBackgroundMusic();
    }

    protected override void InitReferences() {
      base.InitReferences();
      if (!MusicManager) {
        MusicManager = FindObjectOfType<MusicManager>();
      }
    }

    private void PlayMyBackgroundMusic() {
      var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
      if (MusicManager) {
        MusicManager.OnLevelChanged(scene.buildIndex);
      }
    }

  }
}