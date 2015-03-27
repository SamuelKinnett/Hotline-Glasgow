using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	private Animator animator;
	public Camera camera;
	public GameObject player;

	bool isMoving;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		Vector3 playerPos = player.transform.position;
		
		playerPos.x += inputX / 4;
		playerPos.y += inputY / 4;

		//Credit to robertbu on Stack Overflow
		Vector3 pos = camera.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

		if(inputX != 0 || inputY != 0)
			animator.SetBool("Moving", true);
		else
			animator.SetBool("Moving", false);

		player.transform.position = playerPos;
	}
}
