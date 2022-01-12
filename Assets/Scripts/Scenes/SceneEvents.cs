using UnityEngine;

namespace Cyborg.Scenes {

    public class SceneEvents {
	
        // TODO: Use Scene Config asset, don't hardcode these values
        const string MAIN = "Main";
        const string TITLE = "_TitleMenu";

        public delegate void ChangeSceneHandler(string sceneName);
        public static event ChangeSceneHandler OnChangeScene;

        public static void ChangeScene(string sceneName) {
            if (OnChangeScene != null) {
                OnChangeScene(sceneName);
            }
        }

        public static void LoadTitleScene() {
            ChangeScene(TITLE);
        }

        public static void LoadMainScene() {
            ChangeScene(MAIN);
        }
    }
}
