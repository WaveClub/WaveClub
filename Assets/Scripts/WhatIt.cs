using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WhatIt : MonoBehaviour {
	[SerializeField] private bool uniform = true;
	[SerializeField] private bool autoSetUniform = true;

	public Camera myCamera;

	private void Awake() {
		myCamera.orthographic = true;

		if (uniform)
			SetUniform ();
	}

	private void LateUpdate() {
		if (autoSetUniform && uniform)
			SetUniform ();
	}

	private void SetUniform() {
		float size = myCamera.pixelHeight / 2;
		if (size != myCamera.orthographicSize)
			myCamera.orthographicSize = size;
	}
}
