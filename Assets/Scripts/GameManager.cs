using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject gameScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject[] targets;
    public float spawnInterval = 1.0f;
    private int score = 0;
    private bool isGameActive = false;

    void Start()
    {
        titleScreen.SetActive(true);
        gameScreen.SetActive(false);
    }

    public void BeginGame(int difficulty)
    {
        spawnInterval /= difficulty;
        isGameActive = true;
        titleScreen.SetActive(false);
        gameScreen.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0, targets.Length);
            Instantiate(targets[index]);
        }
    }
    
    public void UpdateScore(int scoreToAdd)
    {
        if (isGameActive)
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
