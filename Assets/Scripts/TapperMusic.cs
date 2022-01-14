using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cyborg.Clinic {

				// Separate component to handle the Tapper music
				// Copy/pasted from BackgroundMusicController
				public class TapperMusic : MonoBehaviour
				{

								private AudioSource source;
								const float fadeTime= 1.0f;
								
								public void FadeOutMusic() {
												// Debug.Log("Fading out music.");
												StartCoroutine(FadeOut(fadeTime));
								}
    
								public void FadeInMusic() {
												source.Play();
												StartCoroutine(FadeIn(fadeTime));
								}
								
								void Start() {
												source = GetComponent<AudioSource>();
												source.volume = 0;
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
																source.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
																yield return null;		
												}	
												yield break;
								}
    
				}

}
