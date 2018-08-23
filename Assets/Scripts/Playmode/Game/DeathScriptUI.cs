using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScriptUI : MonoBehaviour {

	private GameController gameController;

	private void Awake()
	{
		gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();

		gameController.OnGameOver += UpdateUI;

		UpdateUI();
	}

	private void OnDestroy()
	{
		gameController.OnGameOver -= UpdateUI;
	}

	private void UpdateUI()
	{
		gameObject.SetActive(gameController.IsGameOver);
	}
}
