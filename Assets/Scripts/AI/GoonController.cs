using UnityEngine;
using System.Collections;

public class GoonController : MonoBehaviour {

	public GameObject player;

	public bool isMoving;
	public bool isDowned;

	public float speed;

	private Animator animator;
	private BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		collider = this.GetComponent<BoxCollider2D>();
		isMoving = false;
		isDowned = false;
		this.tag = "Enemy";
	}
	
	// Update is called once per frame
	void Update () {
		//if (isDowned == false)
		//{
			RaycastHit2D hit;
			Vector3 target = player.transform.position - transform.position;
			Vector3 normalised = target;
			normalised.Normalize();
			int layerMask = ~(1 << LayerMask.NameToLayer("Enemy"));

			Debug.DrawRay(transform.position, target, Color.red);

			hit = Physics2D.Raycast(transform.position, target, 10, layerMask);
			if (hit.collider != null && hit.collider.tag == "Player")
			{
				//The Bot has found the player
				float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
				
				transform.position += normalised * Time.deltaTime * speed;
				isMoving = true;
			}
			else
			{
				isMoving = false;
			}
		//}
	}

	public void Hit()
	{
		isDowned = true;
		isMoving = false;
		Debug.Log("Enemy downed!");
		animator.SetBool("Downed", true);
		collider.enabled = false;
	}
}
