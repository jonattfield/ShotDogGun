using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SausageScript : MonoBehaviour {
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); 
	}
	
	// Update is called once per frame
	void Update () {
		// If the sausage is moving, ensure it always rotates towards it's direction (like an arrow)
		if (rb.velocity.z > 1.5) {
			transform.rotation = Quaternion.LookRotation (rb.velocity);
		}
	Destroy(gameObject, 3);
	}
}
