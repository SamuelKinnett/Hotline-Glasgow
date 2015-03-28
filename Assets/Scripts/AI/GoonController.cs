using UnityEngine;
using System.Collections;

public class GoonController : MonoBehaviour {

	public GameObject player;

	public bool isMoving;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
			RaycastHit2D hit;
			Vector3 target = player.transform.position - transform.position;
			int layerMask = ~(1 << LayerMask.NameToLayer("Enemy"));

			Debug.DrawRay(transform.position, target, Color.red);

			hit = Physics2D.Raycast(transform.position, target, 10, layerMask);
			if (hit.collider != null && hit.collider.tag == "Player")
				Debug.Log(hit.point);
				//Debug.Log("The ray hit the player!");
			//else
				//Debug.Log(hit.point);
	}
}
