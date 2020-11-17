using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGoblin : MonsterAI
{
    public override void SetState()
    {
        mStates[0] = new State_JumpDown();
        mStates[1] = new State_Idle();
        mStates[2] = new State_Trace();
        mStates[3] = new State_NomalAttack();
        mStates[4] = new State_Damaged();
        mStates[5] = new State_Die();
    }

    void JumpEnd()
    {
        ChangeState(mStates[1]);
    }

    void Attack()
    {
        ((State_NomalAttack)mStates[3]).Attack();
    }
}
