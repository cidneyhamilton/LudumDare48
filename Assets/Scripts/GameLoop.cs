using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyborg.Audio;
using Cyborg.Scenes;
using Cyborg.Dialogue;

namespace Cyborg.Clinic {
    
    public class GameLoop : MonoBehaviour
    {

	void OnEnable() {
	    SceneController.AfterSceneLoad += StartGame;
	}

	void OnDisable() {
	    SceneController.AfterSceneLoad -= StartGame;
	}

	void StartGame() {
	    AudioEvents.PlayMusic("Main Dark");
	    StoryEvents.Continue();
	}
    }

}
