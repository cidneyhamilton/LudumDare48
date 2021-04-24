using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cyborg.Dialogue {
    
    public class Portrait : View
    {

	void OnEnable() {
	    StoryEvents.OnSpeak += Show;
	    StoryEvents.OnHide += Hide;
	}

	void OnDisable() {
	    StoryEvents.OnSpeak -= Show;
	    StoryEvents.OnHide -= Hide;
	}

	void Show(string speaker, string line, List<string> tags) {
	    // Debug.Log("Speaker is " + speaker);
	    // Debug.Log("GameObject is " + gameObject.name);
	    if (speaker == gameObject.name) {
		// Debug.Log("Showing portrait of " + speaker);
		Show();
	    } else {
		// Debug.Log("Hiding portrait of " + gameObject.name);
		Hide();
	    }
	}

	void Start() {
	    Hide();
	}
	
	
    }

}
