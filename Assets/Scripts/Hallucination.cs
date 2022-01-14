using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Cyborg.Dialogue;

namespace Cyborg.Clinic {

				// Handles hallucinations during flashbacks
    public class Hallucination : MonoBehaviour
    {

								// Array of hallucination gameobjects
								public GameObject[] Hallucinations;

								bool showAlternate = false;
	
								void Start() {
												HideAll();
												showAlternate = false;
								}

								void OnEnable() {
												StoryEvents.OnShowHallucination += ShowHallucination;
												StoryEvents.OnHide += HideAll;
												StoryEvents.OnContinue += HideAll;
								}

								void OnDisable() {	    
												StoryEvents.OnShowHallucination -= ShowHallucination;
												StoryEvents.OnHide -= HideAll;
												StoryEvents.OnContinue -= HideAll;
								}
	
								void ShowHallucination() {
												HideAll();
												showAlternate = !showAlternate;
												// if (showAlternate) {		
												int n = Random.Range(0, Hallucinations.Length);
												Hallucinations[n].GetComponent<Image>().enabled = true;
												// }
								}

								void HideAll() {
												for (int i = 0; i < Hallucinations.Length; i++) {
																Hallucinations[i].GetComponent<Image>().enabled = false;
												}
								}

								IEnumerator FadeOutGradually() {
												yield return new WaitForSeconds(0.2f);
												HideAll();
								}
    }
}
