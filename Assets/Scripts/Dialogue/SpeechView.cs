using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Cyborg.Dialogue {

    // View that displays speech from a character
    public class SpeechView : View {
      
        // The Text UI object containing the dialogue text
        public Text speechText;
        TextTyper typer;

	void OnEnable() {
	    StoryEvents.OnSpeak += Show;
	    StoryEvents.OnHide += Hide;
	}

	void OnDisable() {
	    StoryEvents.OnSpeak -= Show;
	    StoryEvents.OnHide -= Hide;
	}

	void Awake() {
	   // clickToContinue = GetComponentInChildren<ClickToContinue>();
	    typer = speechText.GetComponent<TextTyper>();
	    
	    if (typer == null) {
                Debug.LogWarning(string.Format("No text typer in speech view {0} in {1}", gameObject.name, gameObject.transform.parent.name));
            }
	}

	// Check to see if the text typer is typing
        public bool IsTyping() {
            if (typer == null) {
                return false;
            } else {
                return typer.IsTyping();   
            }
        }

	// Finish the text typer's typing
        public void FinishTyping() {
            typer.Continue();
        }		

        // Show a spoken line of dialogue
        public void Show(string speaker, string line, List<string> tags) {
	    string modified = line.Replace("/ ", "\n");
	    if (typer == null) {		
                speechText.text = modified;    
            } else {
                typer.UpdateText(modified); 
            }    

	    // Debug.Log("Showing line of dialogue " + line);
            Show();
        }


    }

}

