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
		 currentLocation = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!aiActive)
			return;
		currentState.UpdateState(this);
		move();
	}
	
	private void move()
	{
		ApplyForce(Vector3.Scale(vel, new Vector3(-0.05f,-0.05f,-0.05f)));

		if(vel.magnitude < .001 && acc.magnitude == 0)
			vel = new Vector3(0,0,0);
		else
			vel += acc;
		vel = Vector3.ClampMagnitude(vel, speed);
		currentLocation += vel;

		acc = new Vector3(0,0,0);

		gameObject.transform.position = currentLocation;
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
    	acc += force;
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}
