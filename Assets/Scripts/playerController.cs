﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	
	private Animator animator;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		if (vertical > 0) {
			//animator.SetInteger ("Direction", 1);
		} else if (vertical < 0) {
			//animator.SetInteger ("Direction", 3);
		} else if (horizontal > 0) {
			animator.SetInteger ("Direction", 2);
		} else if (horizontal < 0) {
			animator.SetInteger ("Direction", 4);
		} else {
			animator.SetInteger ("Direction", 0);
		}
	}

}