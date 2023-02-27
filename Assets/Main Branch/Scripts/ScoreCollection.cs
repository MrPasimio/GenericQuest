using UnityEngine;
using TMPro;

public class ScoreCollection : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public void OnEnemyDestroyed(int Amount)
    {
        score += Amount;
        scoreText.text = "Score: " + score;
    }
}

