using System;
using UnityEngine;

namespace Common {

  public class OptionsManager : MonoBehaviour {

    private const string DifficultyKey = "difficulty";
    private const string MasterVolumeKey = "master_volume";
    private const string UnlockedLevelKey = "level_unlocked";

    private const int MinDifficulty = 1;
    private const int MaxDifficulty = 3;
    private const int DefaultDifficulty = 1;
    private const float MinVolume = 0.0f;
    private const float MaxVolume = 1.0f;
    private const float DefaultVolume = 0.5f;

    public static float MasterVolume {
      get { return PlayerPrefs.GetFloat(MasterVolumeKey, DefaultVolume); }
      set {
        if (IsValidVolume(value)) PlayerPrefs.SetFloat(MasterVolumeKey, value);
        else
          Debug.LogError("Trying to write invalid master volume, " +
            "should be between " + MinVolume + " and " + MaxVolume);
      }
    }

    public static int Difficulty {
      get { return PlayerPrefs.GetInt(DifficultyKey, DefaultDifficulty); }
      set {
        if (IsValidDifficulty(value)) PlayerPrefs.SetInt(DifficultyKey, value);
        else
          Debug.LogError("Trying to write invalid difficulty, " +
            "should be between " + MinDifficulty + " and " + MaxDifficulty);
      }
    }

    public static bool IsLevelUnlocked(int index) {
      return PlayerPrefs.GetInt(LevelKey(index)) == 1;
    }

    public static void SetLevelUnlocked(int index, bool isUnlocked) {
      if (IsValidLevelIndex(index))
        PlayerPrefs.SetInt(LevelKey(index), Convert.ToInt32(isUnlocked));
      else Debug.LogError("Trying to update unexisting level unlock status!");
    }

    public static void RestoreDefaults() {
      Difficulty = DefaultDifficulty;
      MasterVolume = DefaultVolume;
    }

    private static string LevelKey(int levelIndex) {
      return UnlockedLevelKey + "_" + levelIndex;
    }

    private static bool IsValidLevelIndex(int levelIndex) {
      var sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
      return levelIndex >= 0 && levelIndex < sceneCount;
    }

    private static bool IsValidDifficulty(float difficulty) {
      return difficulty >= MinDifficulty && difficulty <= MaxDifficulty;
    }

    private static bool IsValidVolume(float volume) {
      return volume >= MinVolume && volume <= MaxVolume;
    }

  }

}