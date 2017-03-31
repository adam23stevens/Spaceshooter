using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour
{
    public float gameSpeed = 0;
    private BgScroller bgScroller;

    public Vector3 spawnPositionValues;    
    public GameObject hazard;
    public GameObject hazard2;
    public GameObject hazard3;
    public GameObject hazard4;
    public int hazardCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;
        
    public int[] asteroidScoreVals;
    public Text scoreText;
    public Text gameOverText;

    public bool gameOver;
    private int score;

    void Start()
    {        
        gameOver = false;
        score = 0;
        UpdateScore();        
        StartCoroutine(SpawnWaves());        
    }

    void Update()
    {
        if (gameOver) DoGameOver();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);            
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (!gameOver)
        {            
            for (int cnt = 0; cnt <= hazardCount; cnt++)
            {                
                SpawnEnemy(UnityEngine.Random.Range(0, 10) >= 4 ? hazard : hazard3);
                if (10 % ++cnt == 0)
                {
                    SpawnEnemy(hazard2);
                }
                yield return new WaitForSeconds(spawnWait);
            }
            int spawnAmount = UnityEngine.Random.Range(0, 3);
            for (int x = 0; x <= spawnAmount; x++)
            {
                SpawnEnemy(hazard4);
            }
            yield return new WaitForSeconds(waveWait);            
            gameSpeed += 1;            
        }        
    }

    private void DoGameOver()
    {
        scoreText.text = "";
        gameOverText.text = string.Format("Game over! Score was: {0} Press R to restart", score);        
    }

    private void SpawnEnemy(GameObject hazard)
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnPositionValues.x, spawnPositionValues.x), spawnPositionValues.y, spawnPositionValues.z);        
        Quaternion spawnRotation = hazard.GetComponent<Transform>().localRotation;
        Instantiate(hazard, spawnPosition, spawnRotation);
    }

    public void addPoints(int points)
    {
        score += points;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = string.Format("Score: {0}", score);
    }
}
