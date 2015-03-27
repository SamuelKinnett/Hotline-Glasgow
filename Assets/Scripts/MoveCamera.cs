using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public GameObject player;

	public int levelWidth;

	float currentSinValue;

	// Use this for initialization
	void Start () {

		currentSinValue = 0;

	}
	
	// Update is called once per frame
	void Update () {
		

		this.transform.position = player.transform.position;

		float distanceFromCentre = this.transform.position.x;
		float rotationMultiplier = 7.5F / (levelWidth / 2);

		/*
		if (currentSinValue <= 360)
			currentSinValue += 0.03F;
		else
			currentSinValue = 0;

		float radianAngle = currentSinValue * 0.0174532925F;
		*/

		//this.transform.rotation = Quaternion.AngleAxis(7.5F * Mathf.Sin(currentSinValue), Vector3.forward);
		this.transform.rotation = Quaternion.AngleAxis(rotationMultiplier * distanceFromCentre, Vector3.forward);
	}
}
