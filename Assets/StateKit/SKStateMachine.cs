using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class SKStateMachine<T,U>
{
	protected T _context;
	#pragma warning disable
	public event Action onStateChanged;
	#pragma warning restore

	public SKState<T,U> currentState { get { return _currentState; } }
	public SKState<T,U> previousState;

	private Dictionary<U,SKState<T,U>> _states = new Dictionary<U,SKState<T,U>>();
	private SKState<T,U> _currentState;


	public SKStateMachine( T context, SKState<T,U> initialState )
	{
		this._context = context;

		// setup our initial state
		initialState.setMachineAndContext( this, context );
		_states[initialState.stateId] = initialState;
		_currentState = initialState;
		_currentState.begin();
	}


	/// <summary>
	/// adds the state to the machine
	/// </summary>
	public void addState( SKState<T,U> state )
	{
		_states[state.stateId] = state;
		state.setMachineAndContext( this, _context );
	}


	public void update( float deltaTime )
	{
		_currentState.reason();
		_currentState.update( deltaTime );
	}


	public virtual void changeState( U newStateId )
	{
		// avoid changing to the same state
		if( _currentState.stateId.Equals( newStateId ) )
			return;

		// only call end if we have a currentState
		if( _currentState != null )
			_currentState.end();

		// swap states and call begin
		previousState = _currentState;
		_currentState = _states[newStateId];
		_currentState.begin();

		// fire the changed event if we have a listener
		if( onStateChanged != null )
			onStateChanged();
	}

}
