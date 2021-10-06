using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    private int score;
    private float spawnDelayTime = 1.0f;
    public bool isGameActive;

   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator SpawnTargets()
    {
        //spawns new target randomly every 1seconds of the spawnDelayTime
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnDelayTime);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
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

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;

        spawnDelayTime /= difficulty; //Another way of writing:  spawnDelayTime = spawnDelayTime / difficulty;

        titleScreen.gameObject.SetActive(false);

        StartCoroutine(SpawnTargets());
        UpdateScore(0);

        
    }
}

