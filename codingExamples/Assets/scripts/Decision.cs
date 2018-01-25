using UnityEngine;

public class Decision : ScriptableObject 
{
	public abstract bool Decide(StateController controller);
}
