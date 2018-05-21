using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    GameObject m_car;
    Rigidbody m_rigidbody;

    [Tooltip("汽车速度"), Range(30, 100)]
    public float m_speed;
    [Tooltip("汽车加速度"), Range(50, 200)]
    public float m_acceleratedSpeed;


    float m_precision = 0.01f;
    bool m_isRun = false;
    float m_currentSpeed;

    float m_HorizotalAxit;
    float m_verticalAxit;


    /************************************************************************/
	// Use this for initialization
	void Start () {
        m_car = gameObject;
        m_rigidbody = gameObject.GetComponent<Rigidbody>();
        if (!m_rigidbody)
            gameObject.AddComponent<Rigidbody>();
	}

    /************************************************************************/
    // Update is called once per frame
    void Update()
    {
        // Calculate current speed
        if (m_isRun && Mathf.Abs(m_currentSpeed) < m_speed)
        {
            m_currentSpeed += m_acceleratedSpeed * Time.deltaTime;
        }
        else if (!m_isRun)
        {
            m_currentSpeed = 0.0f;
        }

        // Move with speed
        Vector3 _forward = transform.forward;
        m_rigidbody.velocity = _forward * m_currentSpeed;
    }

    /************************************************************************/

    public void RunForward()
    {
        if (m_isRun)
            return;

        ChangeMovingState(true);
    }

    /************************************************************************/
    public void Reverse()
    {
        if (m_isRun)
            return;

        ChangeMovingState(false);
        
    }

    public void MoveVertical(float _axis)
    {
        //if (_axis > m_precision)
        //    RunForward();
        //else if (_axis < -1 * m_precision)
            //Reverse(); 

    }

    /************************************************************************/
    /// <summary>
    /// Changes the state of the moving.
    /// </summary>
    /// <param name="isForward">If set to <c>true</c> is forward.</param>
    protected void ChangeMovingState(bool isForward)
    {
        m_isRun = true;

        m_acceleratedSpeed = Mathf.Abs(m_acceleratedSpeed) * (isForward ? 1 : -1);
    }

    /************************************************************************/

    public void Turn()
    {
        
    }

    /************************************************************************/

    public void Stop()
    {
        StartCoroutine(StopProcess());
    }

    /************************************************************************/

    IEnumerator StopProcess()
    {
        // Set currentSlowdown speed
        bool _isCurrentForward = m_currentSpeed > 0.0f ? true : false;
        ChangeMovingState(_isCurrentForward);

        // Judge m_current Speed and stop
        if (Mathf.Abs(m_currentSpeed) < m_precision)
            m_isRun = false;
        else
        {
            yield return new WaitForSeconds(Time.deltaTime * 2);
            yield return StartCoroutine(StopProcess());
        }
    }

    /************************************************************************/


}
