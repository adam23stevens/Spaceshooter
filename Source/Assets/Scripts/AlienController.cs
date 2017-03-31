using UnityEngine;
using System.Collections;

[System.Serializable]
public class AlienBoundary
{
    public float minX, maxX, minZ, maxZ;
}

public class AlienController : MonoBehaviour
{
    private GameController gameController;
    public AlienBoundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float tilt;

    public float speed;
    public float startFireWait;
    public float timeRange;
    public float fireRate;
    public float moveSpeed;
    private Rigidbody rb;
    private bool moveLeft = true;

    void Start()
    {
        GameObject gObj = GameObject.FindGameObjectWithTag("GameController");
        gameController = gObj.GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DoAction());
    }

    IEnumerator DoAction()
    {
        moveSpeed += gameController.gameSpeed;
        fireRate = moveSpeed / 10;
        startFireWait = Random.Range(startFireWait - timeRange, startFireWait + timeRange);
        yield return new WaitForSeconds(startFireWait);
        while (true)
        {
            FireShot();
            rb.velocity = new Vector3(moveLeft ? moveSpeed : -moveSpeed, 0.0f, 0.0f);
            moveLeft = moveLeft ? false : true;

            rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.minX, boundary.maxX),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.minZ, boundary.maxZ)
                );

            rb.rotation = Quaternion.Euler(0.0f, 180, rb.velocity.x  * -tilt);

            yield return new WaitForSeconds(fireRate);
        }
    }

    void FireShot()
    {
        Debug.Log("alienFired");
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
}
