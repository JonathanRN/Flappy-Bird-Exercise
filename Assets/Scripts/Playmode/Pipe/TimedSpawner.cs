using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour {

	[SerializeField] private GameObject prefab;

	[SerializeField] private float spawnPipeDelay = 2f;

	private void OnEnable()
	{
		StartCoroutine(SpawnPipeCoroutine());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private IEnumerator SpawnPipeCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnPipeDelay);
			SpawnPrefab();
			Debug.Log("Spawn by" + gameObject.GetInstanceID());
		}
	}

	private void SpawnPrefab()
	{
		Instantiate(prefab, transform.position, Quaternion.identity);
	}
}
