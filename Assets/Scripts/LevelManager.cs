using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private const string LEVEL_SCENE_FORMAT_NAME = "Level_{0:D2}";

	private const string GAME_SCENE_NAME = "Game";
	private const string WIN_SCENE_NAME = "Win";
	private const string START_SCENE_NAME = "Start";
	private const string LOSE_SCENE_NAME = "Lose";

	public void LoadGameScene() {
		LoadScene(GAME_SCENE_NAME);
	}

	public void LoadWinScene() {
		LoadScene(WIN_SCENE_NAME);
	}

	public void LoadLoseScene() {
		// TODO: Make a lose scene
		LoadScene(WIN_SCENE_NAME);
	}

	public void LoadStartScene() {
		LoadScene(START_SCENE_NAME);
	}

	private void LoadScene(string sceneName) {
		var activeSceneName = SceneManager.GetActiveScene().name;
		if (activeSceneName.ToLower().Equals(sceneName.ToLower())) {
			print("Scene with name " + activeSceneName + " is already loaded.");
			return;
		}

		SceneManager.LoadScene(sceneName);
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void LoadLevel(int level) {
		LoadScene(string.Format(LEVEL_SCENE_FORMAT_NAME, level));
	}

	public void LoadNextLevel() {
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		int lastLevelSceneIndex = SceneManager.sceneCountInBuildSettings - 2;

		if (sceneIndex >= lastLevelSceneIndex) {
			LoadWinScene();
			return;
		}

		int firstLevelSceneIndex = 1;
		if (sceneIndex < firstLevelSceneIndex) {
			sceneIndex = firstLevelSceneIndex;
		} 

  		LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
  	}

}
