using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu  (menuName = "PluggableAI/Actions/FindTargets")]
public class FindTargets : Action 
{

	public string seek;
	public string flee;

	public float minAngleBetween = 10;

	public override void Act(StateController controller)
	{
		lookAhead(controller);
	}

	public override void DrawDebug( StateController controller)
	{
		int numberOfRays = (int)(controller.angOfSight/minAngleBetween);
		var castPoint = controller.gameObject.transform;
		
		for(int i = 0; i < numberOfRays; ++i)
		{
			Gizmos.DrawRay(castPoint.position , Quaternion.AngleAxis(i*minAngleBetween - controller.angOfSight/2 , castPoint.up) * castPoint.forward*controller.lineOfSightDistance);
		}
	}


	private void lookAhead(StateController controller)
	{
		List<GameObject> inRange = GetInRangeObjects(controller);
		
		controller.seekTargets.Clear();
		controller.fleeTargets.Clear();
		inRange.ForEach( obj => 
		{
			if(obj.tag == seek)
				controller.seekTargets.Add(obj);
			if(obj.tag == flee)
				controller.fleeTargets.Add(obj);
		});
	}

	private List<GameObject> GetInRangeObjects(StateController controller)
	{
		int numberOfRays = (int)(controller.angOfSight/minAngleBetween);
		var castPoint = controller.gameObject.transform;
		var objsHit = new List<GameObject>();
 		RaycastHit hit;
 		Ray test;
		for(int i = 0; i < numberOfRays; ++i)
		{
			test = new Ray(castPoint.position , Quaternion.AngleAxis(i*minAngleBetween - controller.angOfSight/2 , castPoint.up) * castPoint.forward);
			if(Physics.Raycast( test , out hit ,controller.lineOfSightDistance) )
			{
				if( hit.collider.tag == seek ||hit.collider.tag == flee )
					objsHit.Add(hit.collider.gameObject);
			}
		}
		return objsHit;
	}

}
