using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;

public class WeaponStateMachine : FSM {

	// Use this for initialization
	protected WeaponParent m_weaponCtr;
	protected State m_attackState;
	protected State m_defendState;
	protected State m_pendingState;

	/************************************************/

	public WeaponParent WeaponController{
		set{
			this.m_weaponCtr = value;
		}
	}

	/************************************************/
	protected void Start () {
		base.Start();

		m_attackState = new State("attack", Begin_Attack, Update_Attack, End_Attack);
		m_defendState = new State("defend", Begin_Defend, Update_Defend, End_Defend);
		m_pendingState = new State("pending", Begin_Pending, Update_Pending, End_Pending);

		this.SwichState(m_pendingState);
	}

	/************************************************/	
	// Update is called once per frame
	new protected void Update ()
	{
		base.Update();

		// Debug.Log("weaponFSM update!");		
	}

	/************************************************/

	void OnDestory()
	{
		m_attackState.UnBindEvent();
		m_defendState.UnBindEvent();
	}

	/************************************************/
	void Begin_Attack()
	{
		m_weaponCtr.Attack();
	}

	/************************************************/
	void Update_Attack()
	{
		// Check animate

	}

	/************************************************/
	void End_Attack()
	{
		m_weaponCtr.StopAttack();
	}

	/************************************************/
	
	void Begin_Defend()
	{
		m_weaponCtr.Defend();
	}

	/************************************************/
	void Update_Defend()
	{
		// check animate over
		if (m_weaponCtr.IsDefendOver())
		{
			this.SwichState(m_pendingState);
			return;
		}
	}

	/************************************************/
	void End_Defend()
	{
		m_weaponCtr.StopDefend();
	}

	/************************************************/
	
	void Begin_Pending()
	{
		m_weaponCtr.Pending();
	}

	/************************************************/
	void Update_Pending()
	{
		// Check whether ready animate play over or not

		// Turn to attack
		if (m_weaponCtr.IsAttackPress())
		{
			this.SwichState(m_attackState);
			return;
		}

		// Turn to defend
		if(m_weaponCtr.IsDefendPress())
		{
			this.SwichState(m_defendState);
			return;
		}

	}

	/************************************************/
	void End_Pending()
	{

	}

	/************************************************/

}
