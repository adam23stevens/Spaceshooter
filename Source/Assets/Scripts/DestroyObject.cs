using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
		
	void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
