using UnityEngine;
using System.Collections;

public class PlanePilot : MonoBehaviour {
	public float frontSpeed;
	private float speedMultiplier;
	private int camMode;
	private float throttleInput;

	// Use this for initialization
	void Start ()
	{
		camMode = 2;
		speedMultiplier = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		CameraOrientation ();
		if (Input.GetKeyDown (KeyCode.C))
		{
			if(camMode == 1)
			{
				camMode = 2;
			}
			else{camMode = 1;}
		}

		ThrottleAndFlight ();

		float terrainHeightPos = Terrain.activeTerrain.SampleHeight (transform.position);
		if (terrainHeightPos > transform.position.y)
		{
			transform.position = new Vector3(transform.position.x, terrainHeightPos, transform.position.z);
		}
	}

	void CameraOrientation()
	{
		Vector3 moveCamToTPV = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
		Vector3 moveCamToFPV = transform.position + transform.forward * 6.0f;
		float bias = 0.82f;
		if (camMode == 1)
		{
			Camera.main.transform.position = moveCamToFPV;
			Camera.main.transform.rotation = transform.rotation;
		}
		if (camMode == 2)
		{
			Camera.main.transform.position = Camera.main.transform.position * bias + moveCamToTPV * (1.0f - bias);
			Camera.main.transform.LookAt (transform.position + transform.forward * 30.0f);
		}
	}

	//I don't know how to do the throttle control exactly,
	//So if anyone has a better version, please let me know.
	void ThrottleAndFlight()
	{
		throttleInput = Input.GetAxis ("Throttle");
		if (throttleInput > 0) {
			speedMultiplier += 0.005f;
		} else if (throttleInput < 0) {
			speedMultiplier -= 0.005f;
		} else {
			speedMultiplier = speedMultiplier;
		}
		if (speedMultiplier < 0.5f) {
			speedMultiplier = 0.5f;
		}
		if (speedMultiplier > 1.7f) {
			speedMultiplier = 1.7f;
		}
		transform.position += transform.forward * Time.deltaTime * frontSpeed * speedMultiplier;
		frontSpeed -= transform.forward.y * Time.deltaTime * 20f;
		if (frontSpeed < 35f)
		{
			frontSpeed = 35f;
		}
		transform.Rotate(Input.GetAxis("Pitch"), 0.0f, -Input.GetAxis ("Roll")*3);
		SpeedUI.speed = (frontSpeed * speedMultiplier);
		HeightUI.height = transform.position.y;
		Debug.Log (frontSpeed * speedMultiplier);
	}
}
