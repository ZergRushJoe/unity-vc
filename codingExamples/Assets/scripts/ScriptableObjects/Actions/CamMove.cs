using UnityEngine;

[CreateAssetMenu  (menuName = "PluggableAI/Actions/CamMove")]
public class CamMove : Action 
{

	public float zOffset = 0;

	public override void Act ( StateController controller )
	{
		MoveCam(controller);
	}

	public override void DrawDebug( StateController controller)
	{

	}

	private void MoveCam( StateController controller )
	{
		controller.gameObject.transform.position = new Vector3(controller.playerObject.transform.position.x,
															   controller.gameObject.transform.position.y,
															   controller.playerObject.gameObject.transform.position.z+zOffset);
	}

}
