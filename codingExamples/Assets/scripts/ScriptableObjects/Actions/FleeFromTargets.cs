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

	private void ApplyMovementForce(StateController controller)
	{
		for(int i = 0; i < controller.fleeTargets.Count; ++i)
		{
			Vector3 vectorToTarget = controller.currentLocation - controller.fleeTargets[i].GetComponent<Transform>().position;
			Vector3 rawForce = Vector3.ClampMagnitude(vectorToTarget, 1/vectorToTarget.magnitude);
			if(rawForce.magnitude > maxForce)
				controller.ApplyForce(Vector3.ClampMagnitude(rawForce,maxForce));
			else
				controller.ApplyForce(rawForce);
		}
	}
}
