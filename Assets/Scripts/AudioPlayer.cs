using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {
    
    public static AudioPlayer instance { get; private set; }

	private void Awake() {
	    // If the singleton has been initialized, destroy the new instance 
	    if (instance != null && instance != this) {
	       Destroy(gameObject);
	       return;
	    }

	    // Else, keep the instance
	    instance = this;
		// Prevent it from being destroyed when a scene change occurs
	    DontDestroyOnLoad(gameObject);
 	}

}
