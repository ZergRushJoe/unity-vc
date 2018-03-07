using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu  (menuName = "PluggableAI/Decisions/FoundObject")]
public class FoundObject : Decision {

	public string objectTag = "";

	public override bool Decide(StateController controller)
	{
		return CheckFoundObjects(controller);
	}

	public bool CheckFoundObjects(StateController controller)
	{
		for(int i = 0; i < controller.seekTargets.Count; ++i)
		{
			if( controller.seekTargets[i].tag == objectTag)
				return true;
		}
		return false;
	}
}
