using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private const string LEVEL_SCENE_FORMAT_NAME = "Level_{0:D2}";

    private const string START_SCENE_NAME = "Start";
    private const string GAME_SCENE_NAME = "Game";
    private const string RESULT_SCENE_NAME = "Result";

	public void LoadGameScene() {
        GameManager.ResetScore();
		LoadScene(GAME_SCENE_NAME);
	}

    public void LoadResultScene(bool won) {
        LoadScene(RESULT_SCENE_NAME);
        GameManager.SetResult(won);
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
            LoadResultScene(false);
			return;
		}

		int firstLevelSceneIndex = 1;
		if (sceneIndex < firstLevelSceneIndex) {
			sceneIndex = firstLevelSceneIndex;
		} 

  		LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
  	}

}
