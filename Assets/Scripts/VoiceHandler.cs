using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyborg.Dialogue;

namespace Cyborg.Clinic {

				[RequireComponent(typeof(AudioSource))]
				public class VoiceHandler : MonoBehaviour
				{
								AudioSource source;
								
								void OnEnable() {
												StoryEvents.OnSpeak += PlayVoiceClip;
												StoryEvents.OnShowSettings += Silent;
								}

								void OnDisable() {
												StoryEvents.OnSpeak -= PlayVoiceClip;
												StoryEvents.OnShowSettings += Silent;
								}

								void Start() {
												source = GetComponent<AudioSource>();
								}

								void Silent() {
												// Silences the voice acting
												source.clip = null;
								}
								
								void PlayVoiceClip(string speaker, string speech, List<string> tags) {
												for (int i = 0; i < tags.Count; i++) {
																string tag = tags[i];
																if (tag.Contains(".ogg")) {
																				// Debug.Log(tag);
																				string clipName = tag.Split('.')[0];
																				// Debug.Log(clipName);
																				AudioClip clip = Resources.Load<AudioClip>("VoiceClips/" + clipName);
																				source.clip = clip;
																				source.Play();
																}
																
												}
								
								}
				}

}
