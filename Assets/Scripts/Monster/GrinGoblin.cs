using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinGoblin : MonsterAI
{
    public override void Start()
    {
        base.Start();

        ChangeState(mStates[1]);
    }

    public override void SetState()
    {
        mStates[1] = new State_Idle();
        mStates[2] = new State_Trace();
        mStates[3] = new State_NomalAttack();
        mStates[8] = new State_Damaged();
        mStates[9] = new State_Die();
    }

    void Attack()
    {
        ((State_NomalAttack)mStates[3]).Attack();
    }

    void Die()
    {
        StartCoroutine(CoroutineDie());
    }

    IEnumerator CoroutineDie()
    {
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
        yield break;
    }
}
