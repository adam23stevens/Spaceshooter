using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {
    public float lifetime;

	void Start () {        
        Destroy(gameObject, lifetime);	
	}
}
