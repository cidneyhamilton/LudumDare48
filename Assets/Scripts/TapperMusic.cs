using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapperMusic : MonoBehaviour
{
    // Copy/pasted from BackgroundMusicController
    // TODO: Encapsulate in separate component
    public void FadeOutMusic() {
	Debug.Log("Fading out music.");
	StartCoroutine(FadeOut(1.0f));
    }
    
    public void FadeInMusic() {
	GetComponent<AudioSource>().Play();
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

    void Start() {
	GetComponent<AudioSource>().volume = 0;
    }
    
}
