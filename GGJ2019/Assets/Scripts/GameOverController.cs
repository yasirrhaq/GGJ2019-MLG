using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
    public ScoreManager scoreManager;
    public Text scoreText;

    private void Update()
    {
        scoreText.text = " " + scoreManager.score;
    }
}
