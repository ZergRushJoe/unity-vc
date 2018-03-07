using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu  (menuName = "PluggableAI/Actions/FleeFromTargets")]
public class FleeFromTargets : Action 
{

	public float maxForce;

	public override void Act(StateController controller)
	{
		ApplyMovementForce(controller);
	}

	public override void DrawDebug( StateController controller)
	{
		
	}

	private void ApplyMovementForce(StateController controller)
	{
		
	}
}
