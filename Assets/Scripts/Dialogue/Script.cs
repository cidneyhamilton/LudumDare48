using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

using Cyborg.Clinic;
using Cyborg.Dialogue;
using Cyborg.Scenes;

namespace GameController {

    public class Script : MonoBehaviour
    {

	// Set this file to your compiled json asset
	public TextAsset script;
	
	// The ink story that we're wrapping
	protected Story _inkStory;

	// Returns true if this story can continue
	public bool canContinue {
	    get {
		return _inkStory.canContinue;
	    }		
	}

	public bool isAssigned {
	    get {
		return _inkStory != null;
	    }
	}

	// Get the text of the currently spoken line without advancing the story
	public string currentText {
	    get {
		return _inkStory.currentText.Trim();
	    }
	}

	void Awake() {
	    _inkStory = new Story(script.text);
	}

	void OnEnable() {
	    StoryEvents.OnRestart += Restart;
	    StoryEvents.OnContinue += Continue;
	    StoryEvents.OnChoosePath += ChoosePath;
	}

	void OnDisable() {
	    StoryEvents.OnRestart -= Restart;
	    StoryEvents.OnContinue -= Continue;
	    StoryEvents.OnChoosePath -= ChoosePath;
	}
	
	void Restart() {
	    _inkStory.ResetState();
	}

	bool IsGameOver() {
	    // Debug.Log("Variable State: IsGameOver: " + _inkStory.variablesState["IsGameOver"].ToString());
	    return (int) _inkStory.variablesState["IsGameOver"] == 1;
	}
	
	void Continue() {		    
	    // Debug.Log("Checking for game over.");
	    if (IsGameOver()) {
		// Debug.Log("Game Over.");
		SceneEvents.ChangeScene("_Title");
	    } else  if (canContinue) {
		NextLine();
	    } else {
		StoryEvents.Hide();
	
	    }
	}

	void NextLine() {
	    string result = _inkStory.Continue().Trim();
	    // Debug.Log("Next line:" + result);
	    if (result != "") {
		string speaker = Parser.Speaker(result);
		string speech = Parser.Speech(result);
		StoryEvents.Speak(speaker, speech, _inkStory.currentTags);
	    } else if (_inkStory.currentTags.Contains("emdr")) {
		Debug.Log("Tags contain EMDR; starting tapper sequence.");
		StoryEvents.Hide();
		TapperEvents.StartSequence();
	    }
	}
	
	void ChoosePath(string knotName) {
	    try {
		_inkStory.ChoosePathString(knotName);
		NextLine();
	    } catch (StoryException e) {
		Debug.LogError(string.Format("No knot specified for {0}; check the Ink script.", knotName));
		Debug.LogException(e);

	    }
	}

    }

}
