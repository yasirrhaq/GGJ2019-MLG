using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    public int score;
    public Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int value, bool updateUI = true)
    {
        score += value;

        if (updateUI)
        {
            UpdateScoreText();
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
