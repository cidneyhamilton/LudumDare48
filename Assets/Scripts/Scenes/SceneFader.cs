using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cyborg.Scenes {
	
    public class SceneFader : MonoBehaviour
    {
	
	// True if the scene is currently fading
	public bool isFading;
	public float duration = 1f;
	
	private CanvasGroup fadeCanvas;
	
	public IEnumerator FadeOut() {
	    yield return Fade(1.0f);
	}
	
	public IEnumerator FadeIn() {
	    yield return Fade(0.0f);
	}
	
	void Start()  {
	    fadeCanvas = GetComponent<CanvasGroup>();
	    fadeCanvas.alpha = 1f;
	}
	
	IEnumerator Fade(float finalAlpha) {
	    
	    isFading = true;
	    fadeCanvas.blocksRaycasts = true;
	    
	    float fadeSpeed = Mathf.Abs(fadeCanvas.alpha - finalAlpha) / duration;
	    
	    // Update alpha
	    while (!Mathf.Approximately(fadeCanvas.alpha, finalAlpha)) {
		fadeCanvas.alpha = Mathf.MoveTowards(fadeCanvas.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
		yield return null;
	    }
	    
	    fadeCanvas.blocksRaycasts = false;
	    isFading = false;
	}	
    }
    
}
