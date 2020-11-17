using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : State
{
    public override void Enable()
    {
        mMonsterAnimator.SetBool("isJumpDown", false);
    }

    public override void Update()
    {

    }

    public override IEnumerator Coroutine()
    {

        while (true)
        {
            yield return new WaitForSeconds(2f);

            mMonsterAI.ChangeState(mMonsterAI.mStates[2]);

            yield break;
        }
    }
}
