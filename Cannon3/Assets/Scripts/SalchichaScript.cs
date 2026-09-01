using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalchichaScript : MonoBehaviour {
//	Rigidbody rb;
	Rigidbody[] bones;
	private Vector3 rb1;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> (); 
		//bones = rb.GetComponentsInChildren<Rigidbody> ();
		bones = GetComponentsInChildren<Rigidbody> ();		

	}
	
	// Update is called once per frame
	void Update () {
		// If the sausage is moving, ensure it always rotates towards it's direction (like an arrow)
		bool first = true;
		foreach (Rigidbody rb in bones) {
 			if (first){
			 	if (rb.velocity.z > 1.5) {
//				transform.rotation = Quaternion.LookRotation (rb.velocity);
					rb1 = rb.velocity;
					first = false;
					gameObject.transform.rotation = Quaternion.LookRotation (rb1);

			 }


			}

		}


	Destroy(gameObject, 3);
	}
}
