using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText;

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score" + score;
    }
}
