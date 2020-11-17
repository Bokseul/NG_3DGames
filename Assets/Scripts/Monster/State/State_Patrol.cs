using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Patrol : State
{


    public override void Enable()
    {
        mMonsterAnimator.SetBool("isWalk", true);
    }

    public override void Update()
    {

    }

    public override IEnumerator Coroutine()
    {
        //monsterAI.targetPos = monsterAI.transform.position + new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
        //monsterAI.goTarget.transform.position = monsterAI.targetPos;


        while (true)
        {
            yield return new WaitForSeconds(3f);

            mMonsterAI.ChangeState(mMonsterAI.mStates[0]);
            yield break;
        }

    }
}