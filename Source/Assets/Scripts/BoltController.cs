using UnityEngine;
using System.Collections;

public class BoltController : MonoBehaviour {

    private GameController gameController;
    public float speed;
	void Start () {
        if (tag.IndexOf("Asteroid") > -1)
        {            
            GameObject gObj = GameObject.FindGameObjectWithTag("GameController");
            gameController = gObj.GetComponent<GameController>();

            speed += gameController.gameSpeed * -1;
        }

        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
