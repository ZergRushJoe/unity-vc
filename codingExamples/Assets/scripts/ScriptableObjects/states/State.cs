using UnityEngine;

[CreateAssetMenu  (menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
	public Action[] actions;
	public Transition[] transitions;
	public Color gizmoColor = Color.grey;

	public void UpdateState(StateController controller)
	{
		DoActions (controller);
		CheckTransitions (controller);
	}

	public void DrawDebug(StateController controller)
	{
		for(int i = 0; i < actions.Length; ++i)
		{
			actions[i].DrawDebug(controller);
		}
	}

	private void DoActions(StateController controller)
	{
		Gizmos.color = gizmoColor;
		for(int i = 0; i < actions.Length; ++i)
		{
			actions[i].Act(controller);
		}
	}

    private void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++) 
        {
            bool decisionSucceeded = transitions[i].decision.Decide (controller);
            if (decisionSucceeded) 
                controller.EqueueNextState(transitions[i].trueState);
            else 
                controller.EqueueNextState(transitions[i].falseState);
        }
    }

}
