using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour {

	[SerializeField] private int speed = 3;
	TranslateMover translateMover;

	// Use this for initialization
	void Start () {
		translateMover = GetComponent<TranslateMover>();
	}
	
	// Update is called once per frame
	void Update () {
		translateMover.Move(Vector3.left * speed * Time.deltaTime);
	}
}
