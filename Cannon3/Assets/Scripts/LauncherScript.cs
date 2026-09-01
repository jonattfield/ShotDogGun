using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Starting in x seconds.
// a projectile will be launched every x seconds

public class LauncherScript : MonoBehaviour {
	public GameObject BurgerPrefab;
	public float burgerForce;
	public float burgerInterval;
	Vector3 launcherPos;
	void Start()
	{	
		Vector3 launcherPos = transform.eulerAngles;
		InvokeRepeating("LaunchProjectile", Random.Range( burgerInterval, (burgerInterval * 1.5f) ), Random.Range( burgerInterval, (burgerInterval * 3) ));
	}

	void LaunchProjectile()
	{
		GameObject burgerObject = Instantiate (BurgerPrefab) as GameObject;
		burgerObject.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z) + transform.forward * 2;
		Rigidbody rb = burgerObject.GetComponent<Rigidbody> ();
		rb.transform.rotation = transform.rotation;
		rb.velocity = (transform.forward * burgerForce);

		launcherPos.x = Random.Range(-30f, -17f);
		transform.eulerAngles = launcherPos;
		Destroy(burgerObject.gameObject, 8); // just in case it doesn't destroy
	}
}
