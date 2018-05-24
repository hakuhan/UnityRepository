using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore {

public class FSM : MonoBehaviour {

	protected State m_currentState = new State();
	
	/************************************************/
	// Use this for initialization
	protected void Start () {
		
	}

	/************************************************/
	
	// Update is called once per frame
	protected void Update () {
		// Debug.Log("FSM update!");
		m_currentState.Update();
	}

	/************************************************/
	protected void SwichState(State newState)
	{
		// go to end state
		m_currentState.End();
		
		m_currentState = newState;

		// Turn to next begin state
		m_currentState.Begin();
	}

	/************************************************/

	public bool IsCurrentState(State state)
	{
		return state == m_currentState;
	}	

	/************************************************/

	public State GetCurrentState()
	{
		return m_currentState;
	}

	/************************************************/	
}

}