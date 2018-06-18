﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

	public float horizontalSpeed = 10f;
	public float jumpSpeed = 600f;

	SpriteRenderer sr;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalInput = Input.GetAxisRaw("Horizontal"); // -1: esquerda, 1: direita
		float horizontalplayerSpeed = horizontalSpeed * horizontalInput;
		if (horizontalplayerSpeed != 0){
			MoverHorizontal(horizontalplayerSpeed);
		}
		else{
			StopmovingHorizontal();
		}

		if (Input.GetButtonDown("Jump")){
			Jump();
		}
	}

	void MoverHorizontal(float speed){
		rb.velocity = new Vector2(speed, rb.velocity.y);

		if (speed<0f){
			sr.flipX =true;
		}
		else if (speed> 0f){
			sr.flipX = false;
		}
	}

	void StopmovingHorizontal(){
		rb.velocity = new Vector2(0f, rb.velocity.y);
	}

	void Jump(){
		rb.AddForce(new Vector2(0f, jumpSpeed));
	}

}