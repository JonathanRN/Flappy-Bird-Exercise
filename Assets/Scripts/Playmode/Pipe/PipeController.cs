using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

	[Header("Parts")][SerializeField] private GameObject pipeUp;
	[SerializeField] private GameObject pipeDown;

	[Header("Position")] [SerializeField] private float minHeight = -1;
	[SerializeField] private float maxHeight = 1;
	[SerializeField] private float minDistance = 2;
	[SerializeField] private float maxDistance = 3;

	private BirdSensor birdSensor;
	private PipePassedEventChannel pipePassedEventChannel;

	private void Awake()
	{
		birdSensor = transform.root.GetComponentInChildren<BirdSensor>();
		pipePassedEventChannel = GameObject.FindWithTag("GameController").GetComponent<PipePassedEventChannel>();

		RandomizePipeHeights();
		RandomizePipeDistances();
	}

	private void OnEnable()
	{
		birdSensor.onBirdSensed += NotifyPipePassed;
	}

	private void OnDisable()
	{
		birdSensor.onBirdSensed -= NotifyPipePassed;
	}

	private void NotifyPipePassed()
	{
		Debug.Log("Pipe passed!");
		pipePassedEventChannel.Publish();
	}

	private void RandomizePipeHeights()
	{
		var height = Random.Range(minHeight, maxHeight);
		transform.root.Translate(Vector3.up * height);
	}

	private void RandomizePipeDistances()
	{
		var distance = Random.Range(minDistance, maxDistance);
		transform.root.Translate(Vector3.right * distance);
	}
}
