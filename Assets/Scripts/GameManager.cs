using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int scorePoints;

    public Text scoreText;

    void Start() {
        ResetScore();
    }

    public void Score(int gainedPoints) {
        SetScore(scorePoints + gainedPoints);
    }

    public void ResetScore() {
        SetScore(0);
    }

    private void SetScore(int score) {
        scorePoints = score;
        scoreText.text = scorePoints.ToString();
    }
	
}
