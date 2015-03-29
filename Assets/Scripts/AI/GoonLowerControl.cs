using UnityEngine;
using System.Collections;

public class GoonLowerControl : MonoBehaviour {

	private Animator animator;
	private GoonController goonController;
	private Rigidbody2D playerRigidBody;
	private SpriteRenderer spriteRenderer;

	public GameObject player;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		goonController = player.GetComponent<GoonController>();
		playerRigidBody = player.GetComponent<Rigidbody2D>();
		spriteRenderer = this.GetComponent<SpriteRenderer>();

		animator.SetBool("Forwards", true);
	}
	
	// Update is called once per frame
	void Update () {
		if (goonController.isMoving == true)
			animator.SetBool("Moving", true);
		else
			animator.SetBool("Moving", false);

		transform.up = -playerRigidBody.velocity;

		if (goonController.isDowned = true)
			spriteRenderer.enabled = false;
	}
}
