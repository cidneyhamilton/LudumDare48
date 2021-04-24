using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cyborg.Dialogue {
    
    public class Portrait : View
    {

	void OnEnable() {
	    StoryEvents.OnSpeak += Show;
	    StoryEvents.OnContinue += Hide;
	}

	void OnDisable() {
	    StoryEvents.OnSpeak -= Show;
	    StoryEvents.OnContinue -= Hide;
	}

	void Show(string line, List<string> tags) {
	    Show();
	}
	
	
    }

}
