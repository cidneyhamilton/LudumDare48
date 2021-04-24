using UnityEngine;

namespace Cyborg.Audio {
    
    // Controller to manage playing sound effects
    public class SoundEffectController : SoundController
    {
	// Bind events
	void OnEnable() {
	    AudioEvents.OnPlaySound += PlayClip;
	}
	
	// Unbind events
	void OnDisable() {
	    AudioEvents.OnPlaySound -= PlayClip;
	}
	
	// Plays a sound clip with a given name
	public void PlayClip(string clipName) {
	    AudioClip clip = GetClipByName(clipName);

	    if (clip != null) {
		audioSource.clip = clip;
		audioSource.Play();
	    }
	}
    }    
}

