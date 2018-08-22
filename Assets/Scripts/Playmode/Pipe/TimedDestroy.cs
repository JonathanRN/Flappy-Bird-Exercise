using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour {

	[SerializeField] private float destroyPipeDelay = 20f;

	private void OnEnable()
	{
		StartCoroutine(DestroyPipeCoroutine());
	}

	private void onDisable()
	{
		StopAllCoroutines();
	}

	private IEnumerator DestroyPipeCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(destroyPipeDelay);
			Destroy(transform.root.gameObject);
		}
	}
}
