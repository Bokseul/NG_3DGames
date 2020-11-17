using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterAI : MonoBehaviour
{
    private State mCurrState;
    public State[] mStates { get; protected set; } = new State[10];

    public Animator mAnimator { get; private set; }

    public bool mIsDeath { get; private set; } = false;

    void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        SetState();

        foreach (State state in mStates)
        {
            if(state != null)
                state.Awake(gameObject);
        }

        ChangeState(mStates[0]);
        //gameObject.SetActive(false);
    }

    void Update()
    {
        mCurrState.Update();
    }

    public void ChangeState(State nextState)
    {
        mCurrState = nextState;
        mCurrState.Enable();
        StartCoroutine(mCurrState.Coroutine());
    }

    public abstract void SetState();
}
