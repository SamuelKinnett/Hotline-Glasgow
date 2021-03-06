﻿using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D physics;

	public Camera camera;
	public GameObject player;
	public int speed;

	public GameObject enemyHit;
	public GoonController goonController;

	public bool isMoving;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		physics = this.GetComponent<Rigidbody2D>();
		player.tag = "Player";
	}
	
	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		physics.velocity = new Vector2(0, 0);
		//Vector3 playerPos = player.transform.position;
		
		//playerPos.x += inputX / 4;
		//playerPos.y += inputY / 4;

		//Credit to robertbu on Stack Overflow
		Vector3 pos = camera.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

		if(inputX != 0 || inputY != 0)
		{
			animator.SetBool("Moving", true);
			isMoving = true;
		}
		else
		{
			animator.SetBool("Moving", false);
			isMoving = false;
		}

		//player.transform.position = playerPos;
		physics.velocity = new Vector2(inputX, inputY) * speed;

		if (Input.GetMouseButton(0))
		{
			RaycastHit2D hit; 
			int layerMask = ~(1 << 10);

			hit = Physics2D.Raycast(transform.position, camera.WorldToScreenPoint(Input.mousePosition) - transform.position, 2, layerMask);

			Debug.Log(hit.point);
			if (hit.collider != null && hit.collider.tag == "Enemy")
			{
				enemyHit = hit.transform.gameObject;
				goonController = enemyHit.GetComponent<GoonController>();
				goonController.Hit();
			}
			animator.SetBool("Punching", true);
			//Add code for punching here
		}
		else
			animator.SetBool("Punching", false);
	}
}
