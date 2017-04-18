using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioPlayer : MonoBehaviour {
    
    public static AudioPlayer instance { get; private set; }

    public AudioClip startMusic;
    public AudioClip gameMusic;
    public AudioClip endMusic;

    private AudioSource audioSource;

	void Start() {
	    // If the singleton has been initialized, destroy the new instance 
	    if (instance != null && instance != this) {
	       Destroy(gameObject);
	       return;
	    }

	    // Else, keep the instance
	    instance = this;
		// Prevent it from being destroyed when a scene change occurs
	    DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        loopClip(startMusic);

        SceneManager.sceneLoaded += (Scene scene, LoadSceneMode arg1) => {
            audioSource.Stop();

            if (scene.buildIndex == 0) {
                loopClip(startMusic);
            } else if (scene.buildIndex < SceneManager.sceneCountInBuildSettings - 1) {
                loopClip(gameMusic);
            } else {
                loopClip(endMusic);
            }
        };
 	}

    private void loopClip(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

}
