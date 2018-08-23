using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameControllerEventHandler();

public class GameController : MonoBehaviour {

	private int score;
	private bool isGameStarted;
	private bool isGameOver;

	private PipePassedEventChannel pipePassedEventChannel;
	private BirdDeathEventChannel birdDeathEventChannel;
	private MainController mainController;

	public event GameControllerEventHandler OnScoreChanged;
	public event GameControllerEventHandler OnGameStart;
	public event GameControllerEventHandler OnGameOver;

	public int Score
	{
		get
		{
			return score;
		}
		set
		{
			if (score != value)
			{
				score = value;
				NotifyScoreChanged();
			}
		}
	}

	public bool IsGameStarted
	{
		get
		{
			return isGameStarted;
		}
		set
		{
			if (isGameStarted != value)
			{
				isGameStarted = value;
				NotifyGameStart();
			}
		}
	}

	public bool IsGameOver
	{
		get
		{
			return isGameOver;
		}
		set
		{
			if (isGameOver != value)
			{
				isGameOver = value;
				NotifyGameOver();
			}
		}
	}

	private void Awake()
	{
		mainController = GameObject.FindWithTag(Tags.MainController).GetComponent<MainController>();

		pipePassedEventChannel = GetComponent<PipePassedEventChannel>();
		birdDeathEventChannel = GetComponent<BirdDeathEventChannel>();
	}

	private void Update()
	{
		if (!IsGameStarted)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				IsGameStarted = true;
			}
		}
		else if (IsGameOver)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				mainController.RestartGame();
			}
		}
	}

	private void OnEnable()
	{
		pipePassedEventChannel.OnEventPublished += IncrementScore;
		birdDeathEventChannel.OnEventPublished += OnPlayerDeath;
	}

	private void OnDisable()
	{
		pipePassedEventChannel.OnEventPublished -= IncrementScore;
		birdDeathEventChannel.OnEventPublished -= OnPlayerDeath;
	}

	private void IncrementScore()
	{
		Score++;
	}

	private void OnPlayerDeath()
	{
		IsGameOver = true;
	}

	private void NotifyScoreChanged()
	{
		if (OnScoreChanged != null)
		{
			OnScoreChanged();
		}
	}

	private void NotifyGameStart()
	{
		if (OnGameStart != null)
		{
			OnGameStart();
		}
	}

	private void NotifyGameOver()
	{
		if (OnGameOver != null)
		{
			OnGameOver();
		}
	}
}
