using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Trace : State
{
    public LayerMask mTargetLayer = 1 << 9;
    private PlayerIG mTarget = null;
    private NavMeshAgent mPathFider;

    private bool hasTarget  
    {
        get 
        {
            if (mTarget != null && !mTarget.mIsDeath)    return true;
            return false;
        }
    }

    public override void Awake(GameObject monster)
    {
        base.Awake(monster);
        mPathFider = monster.GetComponent<NavMeshAgent>();
    }


    public override void Enable()
    {        
    }

    public override void Update()
    {

    }


    public override IEnumerator Coroutine()
    {
        while (!mMonsterAI.mIsDeath)
        {
            if (hasTarget)
            {
                mPathFider.isStopped = false;
                mMonsterAnimator.SetBool("isRun", true);

                float distance = Vector3.Magnitude(mTransform.position - mTarget.transform.position);

                
                if (distance != 0f && distance <= mMonsterAI.mSkillDistance)
                {
                    mPathFider.isStopped = true;
                    mMonsterAnimator.SetBool("isRun", false);
                    mMonsterAI.ChangeState(mMonsterAI.mStates[6]);
                }

                else if (distance <= 2f)
                {
                    mPathFider.isStopped = true;
                    mMonsterAnimator.SetBool("isRun", false);
                    mMonsterAI.ChangeState(mMonsterAI.mStates[3]);
                }

                else
                {
                    mPathFider.SetDestination(mTarget.transform.position);
                }
            }
            else
            {
                mPathFider.isStopped = true;
                mMonsterAnimator.SetBool("isRun", false);

                Collider[] colliders = Physics.OverlapSphere(mTransform.position, 35f, mTargetLayer);

                for (int i = 0; i < colliders.Length; ++i)
                {
                    PlayerIG player = colliders[i].GetComponent<PlayerIG>();

                    if (player != null && !player.mIsDeath)
                    {
                        mTarget = player;
                        break;
                    }
                }

                
            }

            yield return new WaitForSeconds(0.5f);
        }

        yield break;
    }

    public override void Disable()
    {
        mPathFider.isStopped = true;
        mMonsterAnimator.SetBool("isRun", false);
    }
}
