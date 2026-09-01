//  THIS FILE IS CURRENTLY NOT IN USE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class ExampleClass : MonoBehaviour {
//	public Vector3 com;
//	public Rigidbody rb;
//	void Start() {
//		rb = GetComponent<Rigidbody>();
//		rb.centerOfMass = com;
//	}
//}
public class CannonController : MonoBehaviour {

	public Camera gameCamera;
	public GameObject cannonBase;
	public GameObject BulletPrefab;
	public float bulletForce;


	// Use this for initialization
	void Start () {
 	}
	
	// Update is called once per frame
	void Update () {

		Vector2 mousePosition = Input.mousePosition;
		Vector3 worldPosition = gameCamera.ScreenToWorldPoint (new Vector3 (mousePosition.x, mousePosition.y, transform.position.z - gameCamera.transform.position.z));

//		if (worldPosition.x > cannonBase.transform.position.x + 1) {
			cannonBase.transform.localEulerAngles = new Vector3 (
				cannonBase.transform.localEulerAngles.x,
			cannonBase.transform.localEulerAngles.y,
				Mathf.Atan2((worldPosition.y - cannonBase.transform.position.y),(worldPosition.x - cannonBase.transform.position.x)) * Mathf.Rad2Deg 
			);
//		}

		// Fire the salchicha
		if (Input.GetMouseButtonDown (0)) {

			GameObject bulletObject = Instantiate (BulletPrefab) as GameObject;
			bulletObject.transform.position = cannonBase.transform.position + cannonBase.transform.right * 3;


//	/*		Rigidbody rb = bulletObject.GetComponent<Rigidbody> ();
	//		rb.transform.rotation = cannonBase.transform.rotation;
//			rb.velocity = (cannonBase.transform.right * bulletForce);
// */

//			foreach (Rigidbody rb in bones) {
//				rb.velocity = (cannonBase.transform.right * bulletForce);
//			}




 
		}
	}
}
