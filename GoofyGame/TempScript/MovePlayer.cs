#pragma warning disable
using UnityEngine;
using System.Collections.Generic;

public class MovePlayer : MonoBehaviour {
	public Rigidbody2D rb;
	public bool isGrounded = false;

	public void Start() {
		rb = base.GetComponent<UnityEngine.Rigidbody2D>();
	}

	public void Update() {
		Run();
		Jump();
	}

	private void OnCollisionEnter2D(Collision2D collisionInfo) {
		if(collisionInfo.gameObject.CompareTag("Floor")) {
			isGrounded = true;
		}
	}

	public void Run() {
		if(Input.GetKey(KeyCode.A)) {
			rb.AddForce(new Vector2(-1F, 0F), ForceMode2D.Force);
		}
		if(Input.GetKey(KeyCode.D)) {
			rb.AddForce(new Vector2(1F, 0F), ForceMode2D.Force);
		}
	}

	public void Jump() {
		if(isGrounded) {
			if(Input.GetKey(KeyCode.W)) {
				rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
				isGrounded = false;
			}
		}
	}
}
