using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;


    void Awake() {
        // DontDestroyOnLoad(gameObject);
        // Debug.Log("LevelManager not destroyed." + name);
    }

    void Start() {
        if (autoLoadNextLevelAfter <= 0) {
            Debug.Log("Auto Load Level Disabled. Use Positive Number");
        } else {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name) {
        Debug.Log("Level load requested for: " + name);
        //Application.LoadLevel(name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(name); //Updated Version
    }

    public void Quit() {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }



}
