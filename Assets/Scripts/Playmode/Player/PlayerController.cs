using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private KeyCode keyUp = KeyCode.W;
	[SerializeField] private KeyCode keyDown = KeyCode.S;
	[SerializeField] private KeyCode keyLeft = KeyCode.A;
	[SerializeField] private KeyCode keyRight = KeyCode.D;

	TranslateMover translateMover;

	void Awake()
	{
		translateMover = GetComponent<TranslateMover>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(keyUp))
			translateMover.Move(Vector3.up);
		if (Input.GetKeyDown(keyLeft))
			translateMover.Move(Vector3.left);
		if (Input.GetKeyDown(keyDown))
			translateMover.Move(Vector3.down);
		if (Input.GetKeyDown(keyRight))
			translateMover.Move(Vector3.right);
	}
}
