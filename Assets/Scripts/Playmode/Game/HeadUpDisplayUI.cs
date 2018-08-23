using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadUpDisplayUI : MonoBehaviour {

	private GameController gameController;

	private void Awake()
	{
		gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();

		UpdateUI();
	}

	private void OnEnable()
	{
		gameController.OnGameStart += UpdateUI;
	}

	private void OnDisable()
	{
		gameController.OnGameStart -= UpdateUI;
	}

	private void UpdateUI()
	{
		gameObject.SetActive(gameController.IsGameStarted);
	}
}
