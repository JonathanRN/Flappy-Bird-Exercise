using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

	BirdPhysics birdPhysics;
	CollisionSensor collisionSensor;
	GameController gameController;

	private BirdDeathEventChannel birdDeathEventChannel;

	private void Awake()
	{
		birdPhysics = transform.root.GetComponentInChildren<BirdPhysics>();
		collisionSensor = transform.root.GetComponentInChildren<CollisionSensor>();
		gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();

		birdDeathEventChannel = GameObject.FindWithTag(Tags.GameController).GetComponent<BirdDeathEventChannel>();
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
		birdDeathEventChannel.Publish();
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

		if (!gameController.IsGameStarted
			&& transform.root.position.y <= 0)
		{
			birdPhysics.Flap();
		}
	}
}
