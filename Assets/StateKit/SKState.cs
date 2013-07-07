using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class SKState<T,U>
{
	protected SKStateMachine<T,U> _machine;
	protected T _context;
	virtual public U stateId
	{
		get { throw new System.Exception( "stateId property not defined in child class" ); }
	}
	

	public SKState()
	{}

	
	public void setMachineAndContext( SKStateMachine<T,U> machine, T context )
	{
		_machine = machine;
		_context = context;
	}


	public virtual void begin()
	{}
	
	
	public virtual void reason()
	{}
	
	
	public abstract void update( float deltaTime );
	
	
	public virtual void end()
	{}

}
