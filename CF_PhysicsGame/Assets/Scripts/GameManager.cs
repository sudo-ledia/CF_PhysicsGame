using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // public PlayerMovement3D myPlayer;
    public int score;

    public TextMeshProUGUI highScoreDisplay;
    public TextMeshProUGUI scoreDisplay;

    public float endTime = 15.0f;

    const string DIR_DATA = "/Data/";
    const string FILE_HIGH_SCORE = "highScore.txt";
    string PATH_HIGH_SCORE;

    public const string PREF_HIGH_SCORE = "hsScore";

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            Debug.Log("Score Changed");
            if (score > HighScore)
            {
                HighScore = score;
            }
        }
    }

    int highScore;

    public int HighScore
    {
        get 
        { 
            //highScore = PlayerPrefs.GetInt(PREF_HIGH_SCORE);
            return highScore;
        }
        set
        {
            highScore = value;

            Directory.CreateDirectory(Application.dataPath + DIR_DATA);
            File.WriteAllText(PATH_HIGH_SCORE, "" + HighScore);

            //PlayerPrefs.SetInt(PREF_HIGH_SCORE, highScore);
        }

    }

    void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        PATH_HIGH_SCORE = Application.dataPath + DIR_DATA + FILE_HIGH_SCORE;
        highScoreDisplay.enabled = false;
        //myPlayer = FindObjectOfType<PlayerMovement>(); no longer used to update score

        if (File.Exists(PATH_HIGH_SCORE))
        {
            HighScore = Int32.Parse(File.ReadAllText(PATH_HIGH_SCORE));
        }

        
    }

    // Update is called once per frame
    void Update()
    { 
        highScoreDisplay = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        scoreDisplay = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        
        // score = myPlayer.score;

        scoreDisplay.text = "Score: " + Score;
        highScoreDisplay.text = "High Score: " + HighScore;

        endTime -= Time.deltaTime; //subtrating delta time from time variable to count down time to 0

        if(endTime <= 0.0f)
        {
            highScoreDisplay.enabled = true;
        }

        if(Input.GetKey(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //or
            // SceneManager.Load("GameScene");
        }

        if(Input.GetKey(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            //or
            // SceneManager.Load("GameScene");
        }
    }
}
