using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunScript : MonoBehaviour {
	public Camera gameCamera;
	public GameObject cannonBase;
	public GameObject BulletPrefab;
	public GameObject Barrel1;	
	public GameObject Barrel2;	
	public Text ReloadText;	
	public float bulletForce;
	public float recoil;	
	private GameObject scoreManager;
	float zDistance = 10;
	int recoilStatus = 0;
	int shot = 0;	
	Vector3 bunPos;


	void  Start (){
		scoreManager = GameObject.Find("MasterScore");
		bunPos = cannonBase.transform.position;
		ReloadText.gameObject.SetActive (false);

	}

	void  Update (){
		Vector2 mousePosition = Input.mousePosition;
//		Vector3 worldPosition = gameCamera.ScreenToWorldPoint (new Vector3 (mousePosition.x, mousePosition.y, transform.position.z - gameCamera.transform.position.z));
		cannonBase.transform.LookAt(gameCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, zDistance)));
 




		// Fire the salchicha
		if (Input.GetMouseButtonDown (0)) {
			
			if (shot < 2) {

				GameObject bulletObject = Instantiate (BulletPrefab) as GameObject;

				if (shot == 0) {
					bulletObject.transform.position = new Vector3((cannonBase.transform.position.x - 0.4f),(cannonBase.transform.position.y + 0.2f),cannonBase.transform.position.z) + cannonBase.transform.forward * 2;
					Barrel1.GetComponent<Renderer>().enabled = false;
				}
				if (shot == 1) {
					bulletObject.transform.position = new Vector3((cannonBase.transform.position.x + 0.1f),(cannonBase.transform.position.y + 0.2f),cannonBase.transform.position.z) + cannonBase.transform.forward * 2;
					Barrel2.GetComponent<Renderer>().enabled = false;
					ReloadText.text = "RELOAD!!!"; 

					ReloadText.gameObject.SetActive (true);
				}

				Rigidbody rb = bulletObject.GetComponent<Rigidbody> ();

				rb.transform.rotation = cannonBase.transform.rotation;
				rb.velocity = (cannonBase.transform.forward * bulletForce);

				StartCoroutine(Recoil());
				shot = shot + 1;
			}




			//var tube = ((shot++ & (int)1) == 0) ? Barrel1 : Barrel2;
			//GameObject.Instantiate(missle, tube.transform.position, tube.transform.rotation);

			else if (shot >= 2) {
				ReloadText.gameObject.SetActive (false);
 				shot = 0;
				Barrel1.GetComponent<Renderer>().enabled = true;
				Barrel2.GetComponent<Renderer>().enabled = true;
				scoreManager.gameObject.SendMessage("ResetPerfect");
			}

		


		}



	}
		


	IEnumerator Recoil()
	{   if (recoilStatus == 0) {
			recoilStatus = 1;
			cannonBase.transform.Translate (new Vector3 (0, 0, -recoil) * Time.deltaTime * 2); 
			yield return new WaitForSeconds (0.2F);
			cannonBase.transform.Translate (new Vector3 (0, 0, recoil) * Time.deltaTime * 2);
			recoilStatus = 0;
			cannonBase.transform.position = bunPos; // seems to go walkabout sometimes, so this resets position
		}
	}



}