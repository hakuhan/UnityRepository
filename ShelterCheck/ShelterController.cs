using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterController : MonoBehaviour {

	public int m_checkRate = 2;
	public bool m_ShowStart = true;
	private bool m_isShow;
	private Transform m_camera;
	private Material[] m_alphaMeterials;
	private Material[] m_preMaterials;
	/******************************************************/
	// Use this for initialization
	void Start () {
		m_camera = GameObject.FindWithTag("MainCamera").transform;
        var _collider = m_camera.GetComponent<Collider>();
        if (!_collider)
            m_camera.AddComponent<SphereCollider>();
        
		m_preMaterials = gameObject.GetComponent<Renderer>().materials;
		
		// Init transparent material
		Material alphaM = Resources.Load<Material>("Materials/TransparentMaterial");
		m_alphaMeterials = new Material[m_preMaterials.Length];
		for (int i = 0; i < m_alphaMeterials.Length; ++i)
		{
			m_alphaMeterials[i] = alphaM;
		}

		// Set defaul
		m_isShow = m_ShowStart;
		SetMaterial(m_ShowStart);
		StartCoroutine(ShelterControll());
	}
	
	/******************************************************/
	// Update is called once per frame
	void Update () {
		
	}

	/******************************************************/

	IEnumerator ShelterControll() {
		Vector3 m_direction = m_camera.position - transform.position;
		RaycastHit hit;
		bool shieding = false;
		if (Physics.Raycast(transform.position, m_direction, out hit))
		{
			Debug.DrawLine(m_camera.position, transform.position, Color.red, 1.0f);
			// Gizmos.DrawLine(m_camera.position, transform.position);
			shieding = hit.transform.gameObject.GetInstanceID() == m_camera.gameObject.GetInstanceID();
		}

		// Show or hide
		if (m_isShow != shieding)
		{
			SetMaterial(shieding);

			m_isShow = shieding;
		}
		
		yield return new WaitForSeconds(1.0f/m_checkRate);
		StartCoroutine(ShelterControll());
	}

	/******************************************************/

	protected void SetMaterial(bool isShow)
	{
		if (isShow)
		{
			Debug.Log(gameObject.name + " Show!");
			gameObject.GetComponent<Renderer>().materials = m_preMaterials;
		}
		else
		{
			gameObject.GetComponent<Renderer>().materials = m_alphaMeterials;
			Debug.Log(gameObject.name + " Hide!");			
		}
	}

	/******************************************************/
	
	
}
