using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscript : MonoBehaviour
{
    public static UIscript Instance;

    private Text scoreText;
    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public int Score
    {
        get => score;
        set
        {
            score = value;
            UpdateScoreText(score);
        }
    }

    void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        score = 0;
    }

}
