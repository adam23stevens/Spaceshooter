using UnityEngine;
using System.Collections;
using System;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;    

    private GameController gameController;
     

    void Start()
    {
        GameObject gObject = GameObject.FindGameObjectWithTag("GameController");
        if (gObject != null)
        {
            gameController = gObject.GetComponent<GameController>();
        } 
        if (gameController == null)
        {
            Debug.Log("Failed to find GameController");
        }
    }

    void DoExplosion(Collider other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {        
        if (!other.CompareTag("Boundry"))
        {            
            if (other.CompareTag("Player") || (tag == "EnemyBolt" && other.CompareTag("Player")))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                DoExplosion(other);
                gameController.gameOver = true;
            }
            else if (other.CompareTag("Bolt")) 
            {
                switch(tag)
                {
                    case "Asteroid1":
                        gameController.addPoints(gameController.asteroidScoreVals[0]);
                        break;
                    case "Asteroid2":
                        gameController.addPoints(gameController.asteroidScoreVals[1]);
                        break;
                    case "Asteroid3":
                        gameController.addPoints(gameController.asteroidScoreVals[2]);
                        break;
                    case "Alien":
                        gameController.addPoints(gameController.asteroidScoreVals[3]);
                        break;
                }
                DoExplosion(other);
            }            
        }
    }  
}
