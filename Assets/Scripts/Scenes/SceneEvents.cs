using UnityEngine;

namespace Cyborg.Scenes {

	public class SceneEvents {

		public delegate void ChangeSceneHandler(string sceneName);
		public static event ChangeSceneHandler OnChangeScene;

		public static void ChangeScene(string sceneName) {
			if (OnChangeScene != null) {
				OnChangeScene(sceneName);
			}
		}
	}
}
