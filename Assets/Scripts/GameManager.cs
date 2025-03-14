using UnityEngine;
using TMPro;



public class GameManager: MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI startMessage;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject GetReady;
    [SerializeField] private AudioSource scoreSound;
    [SerializeField] private AudioSource deathSound;

    public Player player;

    public int Score = 0;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best Score: " + highScore.ToString();
        Pause();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void Play()
    {
        Score = 0;
        scoreText.text = "Current Score: " + Score.ToString();
        gameOver.SetActive(false);
        startMessage.text = "";
        playButton.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
            Destroy(pipes[i].gameObject);
    }
    private void Update()
    {
        
    }

    public void IncreaseScore()
    {
        Score++;
        scoreSound.Play();
        scoreText.text = "Current Score: " + Score.ToString();
        if (Score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", Score);
            PlayerPrefs.Save();
        }
    }

    public void GameOver()
    {
        deathSound.Play();
        gameOver.SetActive(true);
        startMessage.text = "PRESS ENTER OR CLICK";
        playButton.SetActive(true);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best Score: " + highScore.ToString();
        Pause();
    }
}
