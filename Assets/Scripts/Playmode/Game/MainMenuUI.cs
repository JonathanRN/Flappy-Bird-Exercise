﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {

	private GameController gameController;

	private void Awake()
	{
		gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();

		gameController.OnGameStart += UpdateUI;

		UpdateUI();
	}

	private void OnDestroy()
	{
		gameController.OnGameStart -= UpdateUI;
	}

	private void UpdateUI()
	{
		gameObject.SetActive(!gameController.IsGameStarted);
	}
}
