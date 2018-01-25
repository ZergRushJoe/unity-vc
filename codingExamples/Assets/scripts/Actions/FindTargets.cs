using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargets : Action 
{

	public string seek;
	public string flee;

	public override void Act(StateController controller)
	{
		lookAhead(controller);
	}

	private void lookAhead(StateController controller)
	{
		var inRange = GetInRangeObjects(controller);
		var inView = new List<GameObject>();
		for(int i = 0; i<inRange.Count;++i)
		{
			if(CheckInRange(inRange[i],controller))
				inView.Add(inRange[i]);
		}

		controller.seekTargets.Clear();
		controller.fleeTargets.Clear();

		for(int i = 0; i<inView.Count;++i)
		{
			if(inView[i].tag == seek)
				controller.seekTargets.Add(inView[i]);
			else if(inView[i].tag == flee)
				controller.fleeTargets.Add(inView[i]);
		}
	}

	private List<GameObject> GetInRangeObjects(StateController controller)
	{
		Collider[] hitColliders = Physics.OverlapSphere(controller.currentLocation, controller.lineOfSightDistance);
		var inRange = new List<GameObject>();
		for(int i = 0; i < hitColliders.Length;++i)
		{
			inRange.Add(hitColliders[i].gameObject);
		}
		return inRange;
	}

	private bool CheckInRange(GameObject inRange, StateController controller)
	{
		var vectorToTarget = (controller.currentLocation - inRange.transform.position).normalized;
		return Vector3.Angle(controller.gameObject.transform.forward,vectorToTarget) < controller.AngOfSight/2;
	}

}
