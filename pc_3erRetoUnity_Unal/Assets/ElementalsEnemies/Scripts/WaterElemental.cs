﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterElemental : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		transform.position = transform.position + new Vector3 (0f, 0.5f, 0f);
	}
}
