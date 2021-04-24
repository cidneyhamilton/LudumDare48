using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

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

	void Continue() {	    	   
	    if (canContinue) {
		NextLine();
	    } else {
		StoryEvents.Hide();
		Debug.Log("Checking for end of game.");
		// check for game over
		bool isGameOver = _inkStory.variablesState["IsGameOver"].ToString() == "true";
		if (isGameOver) {
		    SceneEvents.ChangeScene("_Title");
		}
	    }
	}

	void NextLine() {
	    string result = _inkStory.Continue().Trim();
	    Debug.Log("Next line:" + result);
	    if (result != "") {
		StoryEvents.Speak(result);
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
