using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour 
{
	public Vector3 currentLocation;
	public Vector3 vel;
	public Vector3 acc;
	public List<GameObject> seekTargets = new List<GameObject>();
	public List<GameObject> fleeTargets = new List<GameObject>();

	public State currentState;
	public float lineOfSightDistance;
	public float AngOfSight;
	public float speed;

	public bool aiActive;

	private State nextState;
	private double stateTimeElapsed = 0;

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
	

	public void EqueueNextState(State nextState)
	{
		if(nextState != currentState && nextState.priorty >= currentState.priorty)
			currentState = nextState;
	}

	public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    public void ApplyForce(Vector3 force)
    {

    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}
