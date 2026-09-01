using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerScript : MonoBehaviour {
	public float spinSpeed = 50f;
	private GameObject scoreManager;
	private int isDead = 0;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.Find("MasterScore");
		isDead = 0;
	}

	// Update is called once per frame
	void Update () {
	//	transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

	}

	void OnCollisionEnter (Collision col){
	//	transform.Rotate(0f, 0f, 0f, Space.Self);
		GetComponent<Rigidbody> ().useGravity = true;


		if (col.gameObject.CompareTag("Salchicha") && (isDead == 0) ) {
			scoreManager.gameObject.SendMessage("UpdateScore");
			isDead = 1;
 			}

		if (col.gameObject.name == "Floor") {
			scoreManager.gameObject.SendMessage("UpdateLives");
		}




		foreach (Transform child in transform) {

			if(child.gameObject.GetComponent<Rigidbody>() == null)
			{
				child.gameObject.AddComponent<Rigidbody>();
				Destroy(child.gameObject, Random.Range( 2.0f, 3.0f ));

			}

		}

	}


}
