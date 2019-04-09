using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Move : MonoBehaviour {

	public GameObject kasou_UI;
	public GameObject Depiction_UI;
	public float smoothTime = 10f;
	public float yVelocity = 0.0f;
	public float x, y, z;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		float newPosition_Y = Mathf.SmoothDamp(Depiction_UI.transform.position.y,
						 kasou_UI.transform.position.y,
						 ref yVelocity,
						 smoothTime);

					Depiction_UI.transform.position += new Vector3(0.1f,0.1f,0.1f);
	}
}
