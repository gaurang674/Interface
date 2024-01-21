using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public Button Restart;
    public bool isGameActive;
    public List<GameObject> targets;
    private float waitTime = 1f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        Restart.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(true);
        isGameActive = false;

    }

    public void StartGame(int difficulty)
    {
        score = 0;
        waitTime /= difficulty;
        updateScore(score);
        StartCoroutine(spawnTarget());
        isGameActive = true;
        titleScreen.SetActive(false);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator spawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(waitTime);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
