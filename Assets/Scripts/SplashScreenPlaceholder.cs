using UnityEngine;
using System.Collections;

public class SplashScreenPlaceholder : MonoBehaviour {

	public GameObject player;
	bool fadingOut;

	// Use this for initialization
	void Start () {
		fadingOut = false;
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = player.transform.position;

		if(Input.GetMouseButton(0))
			fadingOut = true;

		if (fadingOut);

	}
}
