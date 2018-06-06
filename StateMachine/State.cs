using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore {

public delegate void StateEvent();
public class State {

	protected string m_stateName;

	StateEvent m_beginEvent;
	StateEvent m_updateEvent;
	StateEvent m_endEvent;

	/************************************************/

	public State()
	{
		
	}

	/************************************************/
	
	public State(string name, StateEvent beginE, StateEvent updateE, StateEvent endE)
	{
		this.m_stateName = name;
		this.m_beginEvent = beginE;
		this.m_updateEvent = updateE;
		this.m_endEvent = endE;
	}

	/************************************************/

	public void Begin()
	{
		if (m_beginEvent != null)
		{
			m_beginEvent();
		}
	}

	/************************************************/
	public void Update()
	{
		if (m_updateEvent != null)
		{
			m_updateEvent();
		}
	}

	/************************************************/
	public void End()
	{
		if (m_endEvent != null)
		{
			m_endEvent();
		}
	}

	/************************************************/

	public void UnBindEvent()
	{
		m_beginEvent = null;
		m_updateEvent = null;
		m_endEvent = null;		
	}	

	/************************************************/

	public static bool operator == (State s1, State s2)
	{
		return s1.m_stateName == s2.m_stateName;
	}

	/************************************************/

	public static bool operator != (State s1, State s2)
	{
		return s1.m_stateName != s2.m_stateName;
	}

	/************************************************/
	
}
}
