using Common;
using Scenes.Base;

namespace Scenes
{
    public class SplashScreen : SceneWithOwnMusic
    {
        public float Duration = 3.0f;

        public override void Start()
        {
            base.Start();
            Invoke(Name.OfMethod(
                NavigateToNextSceneWithFadeOut), Duration - FadeOut.Duration);
        }
    }
}