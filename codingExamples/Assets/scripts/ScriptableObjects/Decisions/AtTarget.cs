using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu  (menuName = "PluggableAI/Decisions/AtTarget")]
public class AtTarget : Decision 
{
	public float minDistance;

	public override bool Decide(StateController controller)
	{
		return CheckDistance(controller);
	}

	private bool CheckDistance(StateController controller)
	{

		int count = controller.seekTargets.Count;
		if(count == 0)
			return false;
		if(count == 1)
			return (Vector3.Distance(controller.seekTargets[0].transform.position, controller.gameObject.transform.position) < minDistance);
		var avg = new Vector3(0,0,0);
		for(int i = 0;i<count;++i)
		{
			avg += controller.seekTargets[i].transform.position;
		}

		avg = new Vector3(avg.x/count,avg.y/count,avg.z/count);		
		return (Vector3.Distance(avg, controller.gameObject.transform.position) < minDistance);
	}
}
