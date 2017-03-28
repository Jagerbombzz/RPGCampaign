﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

	// Use this for initialization
	void Start () {
		


	}
   public float speed = 3;

   public GameObject target;

	
	// Update is called once per frame
	void Update () {

        Vector3 movementSpeed = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        transform.position = movementSpeed;


    }
}