using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Bird _bird;
    [SerializeField]
    private PipeGenerator _pipeGenerator;
    [SerializeField]
    private StartScreen _startScreen;
    [SerializeField]
    private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;   
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _pipeGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f;
        _bird.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        _gameOverScreen.Open();
    }
}
