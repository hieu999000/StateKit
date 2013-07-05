using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class PatrollingState : SKState<SomeClass,StandardDemoStates>
{
	override public StandardDemoStates stateId
	{
		get { return StandardDemoStates.Patrolling; }
	}
	

	public override void begin()
	{
		Debug.Log( "started patrolling" );
	}
	
	
	public override void update( float deltaTime )
	{
		// do the actual patrolling and once something interesting is near change to chasing state
	}
	

	public override void end()
	{
		Debug.Log( "done patrolling" );
	}

}
