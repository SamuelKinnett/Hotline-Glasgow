using UnityEngine;
using System.Collections;

public class GoonLowerControl : MonoBehaviour {

	private Animator animator;
	private GoonController goonController;
	private Rigidbody2D playerRigidBody;

	public GameObject player;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		goonController = player.GetComponent<GoonController>();
		playerRigidBody = player.GetComponent<Rigidbody2D>();

		animator.SetBool("Forwards", true);
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = player.transform.position;

		if (goonController.isMoving == true)
			animator.SetBool("Moving", true);
		else
			animator.SetBool("Moving", false);

		transform.up = -playerRigidBody.velocity;
	}
}
