using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)] [SerializeField] float GameSpeed=1f;
    [SerializeField] int Score = 0;
    [SerializeField] int PointPerOneShotBlock = 67;
    [SerializeField] int PointPerTwoShotBlock = 93;
    [SerializeField] int PointPerThreeShotBlock = 106;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI HighScoreText;
    string scoreString = "0";
    string HighScoreString = "0";
    int HighScore = 0;
    [SerializeField] bool IsAutoPlayEnabled;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount>1)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }
    void Start()
    {
        scoreText.text = scoreString;
        GetHighScore();
    }

    private void GetHighScore()
    {
        HighScore=PlayerPrefs.GetInt("highscore");
        HighScoreString = HighScore.ToString();
        HighScoreText.text = HighScoreString;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = GameSpeed;
        CheckQuitGame();
        
    }

    private void CheckQuitGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            FindObjectOfType<GameStatus>().DestroyItSelf();
        }
    }

    public void AddScore(string tag)
    {
        if(tag.Equals("one shot"))
        {
            Score += PointPerOneShotBlock;
        }
        else if(tag.Equals("two shot"))
        {
            Score += PointPerTwoShotBlock;
        }
        else if(tag.Equals("three shot"))
        {
            Score += PointPerThreeShotBlock;
        }
        scoreString = Score.ToString();
        scoreText.text = scoreString;
        if(Score>HighScore)
        {
            PlayerPrefs.SetInt("highscore", Score);
            GetHighScore();
        }
    }

    public void DestroyItSelf()
    {
        Destroy(this.gameObject);
    }
    public bool isAutoPlayEnabled()
    {
        return IsAutoPlayEnabled;
    }
}
