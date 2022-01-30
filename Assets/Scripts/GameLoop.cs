using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyborg.Audio;
using Cyborg.Scenes;
using Cyborg.Dialogue;

namespace Cyborg.Clinic {

				// Manages the main game loop
    public class GameLoop : MonoBehaviour
    {

								void OnEnable() {
												SceneController.AfterSceneLoad += StartGame;
												SceneEvents.AfterLoadTitleScene += LoadTitle;
								}

								void OnDisable() {
												SceneController.AfterSceneLoad -= StartGame;
												SceneEvents.AfterLoadTitleScene -= LoadTitle;
								}

								void StartGame() {
												AudioEvents.PlayMusic("Main Dark");
												StoryEvents.Continue();
								}

								void LoadTitle() {
												Debug.Log("Load title scene.");
												AudioEvents.PlayMusic("Main");												
								}
    }

}
