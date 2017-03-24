using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


	public float maximumSpeed = 5.5f;
	public float acceleration = 2f;
	public float jumpingForce = 450f;
	public float jumpingCoolDown = 2f;
	public bool reachedFinishLine = false;

	private float jumpingTimer = 0f;
	private float speed = 0f;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (reachedFinishLine != true) {

			speed += acceleration * Time.deltaTime;

			if (speed > maximumSpeed) { 
				speed = maximumSpeed;
			}

		} else {

			speed -= acceleration * Time.deltaTime;

			if (speed <= 0f) { 
				speed = 0f;
			}
		}


		// Move the player forward
		transform.position += speed * Vector3.forward * Time.deltaTime;

		// Make the Player Jump
		jumpingTimer -= Time.deltaTime;
		if (GvrViewer.Instance.Triggered || Input.GetKeyDown ("space")) {

			if (jumpingTimer <= 0f) {
				jumpingTimer = jumpingCoolDown;
				this.GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpingForce);
			}
		}
		
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Obstacle") {
			speed *= 0.5f;

		}

		if (other.tag == "FinishLine") {
			reachedFinishLine = true;
		}
	}




}
