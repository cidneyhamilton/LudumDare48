using UnityEngine;
using Cyborg.Scenes;

namespace Cyborg.Audio {
    
    // Controller to manage playing sound effects
    public class SoundEffectController : SoundController
    {
								// Bind events
								void OnEnable() {
												AudioEvents.OnPlaySound += PlayClip;
												SceneEvents.AfterLoadTitleScene += Reset;
								}
	
								// Unbind events
								void OnDisable() {
												AudioEvents.OnPlaySound -= PlayClip;
												SceneEvents.AfterLoadTitleScene -= Reset;
								}
	
								// Plays a sound clip with a given name
								public void PlayClip(string clipName) {
												AudioClip clip = GetClipByName(clipName);

												if (clip != null) {
																audioSource.clip = clip;
																audioSource.Play();
												}
								}

								public void Reset() {
												audioSource.clip = null;
												audioSource.Stop();
								}
    }    
}

