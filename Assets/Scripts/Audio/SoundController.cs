using System;
using UnityEngine;

namespace Cyborg.Audio {

	// System sound controller
	
	[RequireComponent(typeof(AudioSource))]
	public abstract class SoundController : MonoBehaviour
	{
		// Store a list of clips in this controller
		public AudioClip[] clips;
		
		// The attached audio source to play this clip
		protected AudioSource audioSource;
		
		void Start() {
			audioSource = GetComponent<AudioSource>();
		}
		
		// Play a given audio clip
		protected void PlayClip(AudioClip clip) {
			
			if (clip == null) {
				// No audio clip to play!
			} else {			   
				// Queue the provided clip in the attached audio source and play it
				audioSource.clip = clip;
				Play();  
			}
		}
		
		// Play the audio source
		void Play() {
			audioSource.Play();
		}		   
		
		// Get the audio clip from the array of clips by name
		protected AudioClip GetClipByName(string clipName) {
			return Array.Find(clips, element => element.name.ToLower() == clipName.ToLower());
		}
		
		// Return true if there's a clip queued matching this clip name
		protected bool IsPlaying(string clipName) {
			return audioSource.clip && audioSource.clip.name.ToLower() == clipName.ToLower();
		}

	}
	
}


