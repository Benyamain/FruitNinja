using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    private int score;

    private void Start() {
        NewGame();
    }

    private void NewGame() {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }
}
