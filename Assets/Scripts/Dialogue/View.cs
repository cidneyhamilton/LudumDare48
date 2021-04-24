using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cyborg.Dialogue {

    public class View : MonoBehaviour
    {
	
	protected bool isFading;
	const float fadeDuration = 0.5f;

	void Start() {
	    // Hide();
	}
	
	public void Toggle(bool isShow) {
	    if (isShow) {
		Show();
	    } else {
		Hide();
	    }
	}
	
	public void TweenIn() {
	    // Array.ForEach(GetComponentsInChildren<UIAnimation>(), element => element.TweenIn());
	}
	
	public void TweenOut() {
	    // Array.ForEach(GetComponentsInChildren<UIAnimation>(), element => element.TweenOut());
	}
	
        public virtual void Show() {
	    if (GetComponent<Canvas>() != null) {
		GetComponent<Canvas>().enabled = true;
	    } else if (GetComponent<CanvasGroup>() != null) {
                GetComponent<CanvasGroup>().alpha = 1f;
                GetComponent<CanvasGroup>().interactable = true;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
            } else {
                gameObject.SetActive(true);     
            }
            
        }

        public virtual void Hide() {
	    if (GetComponent<Canvas>() != null) {
		GetComponent<Canvas>().enabled = false;
	    } else if (GetComponent<CanvasGroup>() != null) {
                GetComponent<CanvasGroup>().alpha = 0f;
                GetComponent<CanvasGroup>().interactable = false;
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            } else {
                gameObject.SetActive(false);    
            }
            
        }
	
	public void FadeIn(Action callback = null) {			
	    CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
	    canvasGroup.alpha = 0f;
	    StartCoroutine(Fade(1f, callback));
	}
	
	public void FadeOut(Action callback = null) {
	    CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
	    canvasGroup.alpha = 1f;
	    StartCoroutine(Fade(0f, callback));
	}
	
	IEnumerator Fade(float finalAlpha, Action callback = null) {
	    CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
	    isFading = true;
			
	    float fadeSpeed = Mathf.Abs(canvasGroup.alpha - finalAlpha) / fadeDuration;
	    
	    while (!Mathf.Approximately(canvasGroup.alpha, finalAlpha)) {
		canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
		yield return null;
	    }
			
	    isFading = false;
			
	    if (callback != null) {
		callback();
	    }
	    
	}
	       	
    }

}

