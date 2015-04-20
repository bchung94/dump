﻿using UnityEngine;
using System.Collections;

public class CameraFollow: MonoBehaviour {

	// default labels
	private string player1Label = "Player1(Clone)";
	private string player2Label = "Player2(Clone)";
	private GameObject player;
	public float height;

	private float minHeight = -2.0f;
	private float maxHeight = 80.0f;
	private float defaultX;
	private float defaultY;
	private float defaultZ;

	// Use this for initialization
	void Start () {
		defaultX = Camera.main.gameObject.transform.position.x;
		defaultY = Camera.main.gameObject.transform.position.y;
		defaultZ = Camera.main.gameObject.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		//find player1 and follow his height
		player = GameObject.Find (player1Label);
		if (player.GetComponent<PhotonView>().isMine) {
			height = (float)player.transform.position.y;
		}
		//if player drops and falls, reset camera to default
		if ((height >= minHeight)&&(height <= maxHeight)) {
			this.gameObject.transform.position = new Vector3(defaultX, height, defaultZ);
		}
		else {
			this.gameObject.transform.position = new Vector3(defaultX, defaultY, defaultZ);
		}
	}
}
