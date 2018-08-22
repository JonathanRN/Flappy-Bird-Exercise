using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameControllerEventHandler();

public class GameController : MonoBehaviour {

	private int score;
	private PipePassedEventChannel pipePassedEventChannel;

	public event GameControllerEventHandler OnScoreChanged;

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

	private void Awake()
	{
		pipePassedEventChannel = GetComponent<PipePassedEventChannel>();
	}

	private void OnEnable()
	{
		pipePassedEventChannel.OnEventPublished += IncrementScore;
	}

	private void OnDisable()
	{
		pipePassedEventChannel.OnEventPublished -= IncrementScore;
	}

	private void IncrementScore()
	{
		Score++;
	}

	private void NotifyScoreChanged()
	{
		if (OnScoreChanged != null)
		{
			OnScoreChanged();
		}
	}
}
