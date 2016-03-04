using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class playerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";


    public static void SetMasterVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master Volume Out of Range");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    //public static void UnlockLevel(int level) {
    //    if (level <= SceneManager.sceneCountInBuildSettings - 1) {
    //        PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //Use one for true
    //    } else {
    //        Debug.LogError("Unlocking level not in build order");
    //    }
    //}

    //public static bool IsLevelUnlocked(int level) {
    //    int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
    //    bool isLevelUnlocked = (levelValue == 1);

    //    if (level <= SceneManager.sceneCountInBuildSettings - 1) {
    //        return isLevelUnlocked;
    //    } else {
    //        Debug.LogError("Unlocking level not in build order");
    //        return false;
    //    }
    //}

    public static void SetDifficulty(float difficulty) {
        if (difficulty >= 1f && difficulty <= 3f) {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        } else {
            Debug.LogError("Difficulty Out of Range");
        }
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}

