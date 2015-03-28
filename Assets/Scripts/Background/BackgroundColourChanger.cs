using UnityEngine;
using System.Collections;

public class BackgroundColourChanger : MonoBehaviour {

	public float time; //How long it takes for the background colour to switch between the two colours.
	float currentTime; //Used to track the current colour in relation to time.
	bool ascending = true; //which way the colour is fading

	public Camera camera;
	private Color colour1;
	private Color colour2;

	// Use this for initialization
	void Start () {
		colour1 = new Color32(39, 253, 245, 255);
		colour2 = new Color32(247, 101, 184, 255);
		currentTime = 0;
	}

	// Update is called once per frame
	void Update () {

		if (ascending && currentTime < time)
			currentTime += 1;
		else if (ascending)
			ascending = false;
		else if (!ascending && currentTime > 0)
			currentTime -= 1;
		else
			ascending = true;

		float currentIntensity = ((180F/time) * currentTime) * 0.0174532925F;

		camera.backgroundColor = Color.Lerp(colour1, colour2, Mathf.Sin(currentIntensity));
	}
}
