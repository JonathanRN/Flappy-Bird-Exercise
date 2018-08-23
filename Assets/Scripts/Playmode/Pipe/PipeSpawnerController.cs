using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerController : MonoBehaviour {

	private GameController gameController;
	private TimedSpawner timedSpawner;

	private void Awake()
	{
		gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();

		Debug.Log("Is enabled at start : " + gameController.IsGameStarted);

		timedSpawner = GetComponent<TimedSpawner>();
	}

	private void Start()
	{
		UpdateSpawner();
	}

	private void UpdateSpawner()
	{
		timedSpawner.enabled = gameController.IsGameStarted;
	}

	private void OnEnable()
	{
		gameController.OnGameStart += UpdateSpawner;
	}

	private void OnDisable()
	{
		gameController.OnGameStart -= UpdateSpawner;
	}

}
