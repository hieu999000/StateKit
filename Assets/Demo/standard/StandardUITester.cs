using UnityEngine;
using System.Collections;


public enum StandardDemoStates
{
	Patrolling,
	Chasing
}

public class StandardUITester : MonoBehaviour
{
	private SKStateMachine<SomeClass,StandardDemoStates> _machine;
	
	
	void Start()
	{
		// our context can be any type at all
		var someClass = new SomeClass();
		
		// the initial state has to be passed to the constructor
		_machine = new SKStateMachine<SomeClass,StandardDemoStates>( someClass, new PatrollingState() );
		_machine.addState( new ChasingState() );
	}
	
	
	void Update()
	{
		_machine.update( Time.deltaTime );
	}
	
	
	void OnGUI()
	{
		if( GUILayout.Button( "Patrolling State" ) )
			_machine.changeState( StandardDemoStates.Patrolling );
		
		if( GUILayout.Button( "Chasing State" ) )
			_machine.changeState( StandardDemoStates.Chasing );
	}
}
