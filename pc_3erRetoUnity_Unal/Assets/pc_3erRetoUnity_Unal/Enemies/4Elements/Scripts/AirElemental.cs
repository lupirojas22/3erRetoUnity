using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirElemental : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		transform.position = transform.position - new Vector3 (0f, 1f, 0f);
	}
}
