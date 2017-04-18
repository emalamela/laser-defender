using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int score;
    public static bool won;

    public Text scoreText;
    public Text resultText;

    void Start() {
        if (resultText != null) {
            resultText.text = won ? "You Won!" : "You Lost!";
        }
        printScore();
    }

    public void ScorePoints(int gainedPoints) {
        score += gainedPoints;
        printScore();
    }

    private void printScore() {
        scoreText.text = "Score - " + score.ToString();
    }

    public static void ResetScore() {
        score = 0;
    }

    public static void SetResult(bool gameWon) {
        won = gameWon;
    }
	
}
