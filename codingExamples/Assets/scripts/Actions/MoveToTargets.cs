using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu  (menuName = "PluggableAI/Actions/MoveToTargets")]
public class MoveToTargets : Action
{

	public float maxForce;

	public override void Act(StateController controller)
	{
		ApplyMovementForce(controller);
	}

	private void ApplyMovementForce(StateController controller)
	{
		for(int i = 0; i < controller.seekTargets.Count; ++i)
		{
			Vector3 vectorToTarget = controller.currentLocation - controller.seekTargets[i].GetComponent<Transform>().position;
			if(vectorToTarget.magnitude > maxForce)
				controller.ApplyForce(Vector3.ClampMagnitude(vectorToTarget, maxForce));
			else
				controller.ApplyForce(vectorToTarget);
		}
	}
}
