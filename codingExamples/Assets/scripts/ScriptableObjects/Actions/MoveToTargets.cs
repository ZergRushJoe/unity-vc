using UnityEngine;

[CreateAssetMenu  (menuName = "PluggableAI/Actions/MoveToTargets")]
public class MoveToTargets : Action 
{

	public override void Act(StateController controller)
	{
		Seek(controller);
	}

	public override void DrawDebug( StateController controller)
	{
		
	}

	private void Seek(StateController controller)
	{
        if (controller.agent != null &&
         (controller.agent.remainingDistance <= controller.agent.stoppingDistance &&
          !controller.agent.pathPending &&
           controller.seekTargets.Count > 0 || 
           controller.stateTimeElapsed % 500 == 0) ) 
        {
            controller.agent.destination =controller.seekTargets[0].transform.position;
        }
	}
}
