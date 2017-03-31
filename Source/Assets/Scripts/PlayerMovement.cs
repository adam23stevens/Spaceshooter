using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float minX, maxX, minZ, maxZ;
}

public class PlayerMovement : MonoBehaviour {
    public GameObject shot;
    public Transform shotSpawn;

    public float speed;
    public Boundary boundary;
    public float tilt;

    public float fireRate;
    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {            
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            nextFire = Time.time + fireRate;
            GetComponent<AudioSource>().Play();
        }
    }

	void FixedUpdate ()
    {        
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.minX, boundary.maxX),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.minZ, boundary.maxZ) 
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
