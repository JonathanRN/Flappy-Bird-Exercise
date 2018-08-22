using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPhysics : MonoBehaviour {

	private new Rigidbody2D rigidbody;

	[SerializeField] private float flapForce = 5;

	private void Awake()
	{
		rigidbody = transform.root.gameObject.AddComponent<Rigidbody2D>();
		rigidbody.fixedAngle = true;
	}

	public void Flap()
	{
		rigidbody.velocity = new Vector2(0, 0);
		rigidbody.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
	}
}
