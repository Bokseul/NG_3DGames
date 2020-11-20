using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterAI : MonoBehaviour
{
    protected State mCurrState;
    public State[] mStates { get; protected set; } = new State[10];

    private Animator mAnimator;
    private NavMeshAgent mPathFider;

    public int mHp = 3;
    public int mMaxHp = 3;
    public int mSpeed = 10;
    public bool mIsDeath = false;

    public bool mChangeTrace = true;
    public float mSkillDistance = 0f;

    void Awake()
    {
        mAnimator = GetComponent<Animator>();
        mPathFider = GetComponent<NavMeshAgent>();
    }

    public virtual void Start()
    {
        SetState();

        foreach (State state in mStates)
        {
            if(state != null)
                state.Awake(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            mHp -= 1;
            Debug.Log(mHp);
            if (mHp > 0)
            {
                ChangeState(mStates[8]);
            }
            else
            {
                ChangeState(mStates[9]);
            }
        }
        mCurrState.Update();
    }

    public void ChangeState(State nextState)
    {
        if(mCurrState != null && nextState != mCurrState)
            mCurrState.Disable();
        mCurrState = nextState;
        mCurrState.Enable();
        StartCoroutine(mCurrState.Coroutine());
    }

    public abstract void SetState();
}
