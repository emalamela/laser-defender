using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void loadGameScene() {
		loadLevel("Game");
	}

	public void loadWinScene() {
		loadLevel("Win");
	}

	public void loadLoseScene() {
		loadLevel("Lose");
	}

	public void loadStartScene() {
		loadLevel("Start");
	}

	private void loadLevel(string levelName) {
		var activeSceneName = SceneManager.GetActiveScene().name;
		if (activeSceneName.ToLower().Equals(levelName.ToLower())) {
			print("Scene with name " + activeSceneName + " is already loaded.");
			return;
		}

		SceneManager.LoadScene(levelName);
	}

	public void quitGame() {
		Application.Quit();
	}
}
