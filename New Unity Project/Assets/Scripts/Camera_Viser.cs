using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Viser : MonoBehaviour {

	public GameObject Main_Camera;
	public GameObject Canvas;
	public Transform m_target      = null;
	public float     m_speed       = 5;
	public float     m_attenuation = 0.5f;

	private Vector3 m_velocity;

	private void Update()
	{

		this.transform.rotation= Quaternion.Euler(Main_Camera.transform.localEulerAngles.x,Main_Camera.transform.localEulerAngles.y,Main_Camera.transform.localEulerAngles.z);
			m_velocity += ( m_target.position - transform.position ) * m_speed;
			m_velocity *= m_attenuation;
			transform.position += m_velocity *= Time.deltaTime;
	}
}
