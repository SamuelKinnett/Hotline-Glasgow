using UnityEngine;
using System.Collections;

public class PlayerLowerScript : MonoBehaviour {

	private Animator animator;

	public GameObject player;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position != player.transform.position)
		{
			this.transform.position = player.transform.position;
			animator.SetBool("Moving", true);
		}
		else
			animator.SetBool("Moving", false);
	}
}
