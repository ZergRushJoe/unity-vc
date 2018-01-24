using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu  (menuName = "PluggableAI/State")]
public abstract class State : ScriptableObject
{

	public Action[] actions;

	public void UpdateState(StateController controller)
	{
		DoActions(controller);
	}

	private void DoActions(StateController controller)
	{
		for(int i = 0; i < actions.Count; ++i)
		{
			actions[i].Act(controller);
		}
	}

}
