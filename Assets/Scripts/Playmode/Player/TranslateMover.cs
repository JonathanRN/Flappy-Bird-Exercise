using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMover : MonoBehaviour {

	[SerializeField] private int speed = 5;

	public void Move(Vector3 direction)
	{
		transform.Translate(direction * speed * Time.deltaTime);
	}
}
