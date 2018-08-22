using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

	BirdPhysics birdPhysics;
	CollisionSensor collisionSensor;

	private void Awake()
	{
		birdPhysics = transform.root.GetComponentInChildren<BirdPhysics>();
		collisionSensor = transform.root.GetComponentInChildren<CollisionSensor>();
	}

	private void OnEnable()
	{
		collisionSensor.OnCollision += Die;
	}

	private void OnDisable()
	{
		collisionSensor.OnCollision -= Die;
	}

	private void Die()
	{
		Hide();
	}

	private void Hide()
	{
		transform.root.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			birdPhysics.Flap();
		}
	}
}
