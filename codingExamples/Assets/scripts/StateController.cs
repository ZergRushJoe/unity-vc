using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour 
{

	public State currentState;
	public float AngOfSight;
	public float speed;

	public bool aiActive;

	void Awake()
	{

	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!aiActive)
			return;
		currentState.UpdateState(this);
	}
	
	public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}
