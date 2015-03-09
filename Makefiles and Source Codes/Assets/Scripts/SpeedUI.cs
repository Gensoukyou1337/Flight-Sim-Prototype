using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//For inputting speed into GUI element of Text type
//Has to be used in conjunction with the PlanePilot.cs

public class SpeedUI : MonoBehaviour {
	public static float speed;
	
	Text text;
	
	void Start()
	{
		text = GetComponent<Text> ();
		speed = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		text.text = "SPEED " + speed.ToString ();
	}
}
