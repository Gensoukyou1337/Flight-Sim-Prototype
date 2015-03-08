using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//For inputting height into GUI element of Text type
//Has to be used in conjunction with the PlanePilot.cs

public class HeightUI : MonoBehaviour {
	public static float height;
	
	Text text;
	
	void Start()
	{
		text = GetComponent<Text> ();
		height = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		text.text = "HEIGHT " + height.ToString ();
	}
}
