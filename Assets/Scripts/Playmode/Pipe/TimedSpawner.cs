﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour {

	[SerializeField] private GameObject prefab;

	[SerializeField] private float spawnPipeDelay = 2f;

	private void OnEnable()
	{
		StartCoroutine(SpawnPipeCoroutine());
	}

	private IEnumerator SpawnPipeCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnPipeDelay);
			SpawnPrefab();
		}
	}

	private void SpawnPrefab()
	{
		Instantiate(prefab, transform.position, Quaternion.identity);
	}
}
