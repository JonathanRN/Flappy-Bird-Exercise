﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BirdSensorEventHandler();


public class BirdSensor : MonoBehaviour {

	public event BirdSensorEventHandler onBirdSensed;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			NotifyBirdSensed();
		}
	}

	private void NotifyBirdSensed()
	{
		if (onBirdSensed != null)
		{
			onBirdSensed();
		}
	}
}
