using System;
using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

namespace Cyborg.Audio {

    // Handles background music for the game
    public class BackgroundMusicController : SoundController
    {
	
	void OnEnable() {
	    AudioEvents.OnPlayMusic += PlayMusic;
	    AudioEvents.OnPause += Pause;
	    AudioEvents.OnUnPause += UnPause;
	    AudioEvents.OnFadeOutMusic += FadeOutMusic;
	    AudioEvents.OnFadeInMusic += FadeInMusic;
	}
		
	void OnDisable() {
	    AudioEvents.OnPlayMusic -= PlayMusic;			
	    AudioEvents.OnPause -= Pause;
	    AudioEvents.OnUnPause -= UnPause;
	    AudioEvents.OnFadeOutMusic -= FadeOutMusic;
	    AudioEvents.OnFadeInMusic -= FadeInMusic;
	}
	
	public void PlayMusic(string clipName) {
	    audioSource.time = 0f;
	    if (IsPlaying(clipName)) {
		// Do Nothing; already playing this clip
	    } else {		
		PlayClip(GetClipByName(clipName));
	    }
	}

	public void FadeOutMusic() {
	    Debug.Log("Fading out music.");
	    StartCoroutine(FadeOut(1.0f));
	}

	public void FadeInMusic() {
	    StartCoroutine(FadeIn(1.0f));
	}

	IEnumerator FadeOut(float duration) {
	    yield return StartCoroutine(FadeMusic(duration, 1.0f, 0.0f));
	}

	IEnumerator FadeIn(float duration) {
	    yield return StartCoroutine(FadeMusic(duration, 0.0f, 1.0f));
	}
	
	IEnumerator FadeMusic(float duration, float startVolume, float targetVolume) {
	    float currentTime = 0;
	    while (currentTime < duration) {
		currentTime += Time.deltaTime;
		GetComponent<AudioSource>().volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
		yield return null;		
	    }
	    
	    yield break;
	}
	
	public void Pause() {
	    audioSource.Pause();
	}
	
	public void UnPause() {
	    audioSource.UnPause();
	}
    }
    
}


