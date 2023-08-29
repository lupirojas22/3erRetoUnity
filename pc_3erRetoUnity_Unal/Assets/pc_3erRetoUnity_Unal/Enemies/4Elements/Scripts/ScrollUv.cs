using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUv : MonoBehaviour {

	public Material toScroll;
	public float scrollSpeed = 1.0f;

	// Use this for initialization
	void Awake () {
		if (toScroll == null) {
			Destroy (this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		toScroll.SetTextureOffset("_MainTex", new Vector2(0f, toScroll.GetTextureOffset("_MainTex").y + (scrollSpeed * Time.deltaTime)));
	}
}
