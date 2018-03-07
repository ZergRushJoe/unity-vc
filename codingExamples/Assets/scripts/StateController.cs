using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour 
{


	public State currentState;
	public float lineOfSightDistance;
	public float angOfSight;
	public GameObject playerObject;
	public bool aiActive;

	[HideInInspector] public Vector3 target;
	[HideInInspector] public NavMeshAgent agent; 
	[HideInInspector] public List<GameObject> seekTargets = new List<GameObject>();
	[HideInInspector] public List<GameObject> fleeTargets = new List<GameObject>();



	private State nextState;
	public double stateTimeElapsed = 0;

	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		if(agent == null) return;

        if (aiActive) 
        {
            agent.enabled = true;
        } else 
        {
            agent.enabled = false;
        }
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

	void OnDrawGizmos()
    {
        if (currentState != null) 
        {
            currentState.DrawDebug(this);
        }
    }

	public void EqueueNextState(State nextState)
	{
		if(nextState != currentState)
		{
			currentState = nextState;
			stateTimeElapsed = 0;
		}
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
