using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;
    private playerPrefsManager playerPrefsManager;

    // Use this for initialization
    void Awake() {
        DontDestroyOnLoad(gameObject);
        Debug.Log("MusicPlayer not destroyed." + name);
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = playerPrefsManager.GetMasterVolume();
    }

    void OnLevelWasLoaded(int level) {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        Debug.Log("Playing clip: " + thisLevelMusic);
        if (thisLevelMusic) {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update() {
    }

    public void ChangeVolume(float volume) {
        audioSource.volume = volume;
    }
}

