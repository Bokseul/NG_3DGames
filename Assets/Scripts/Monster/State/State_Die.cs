using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Die : State
{
    public override void Enable()
    {
        mMonsterAI.gameObject.SetActive(false);
    }

    public override void Update()
    {
        mMonsterAI.ChangeState(mMonsterAI.mStates[1]);
    }

    public override IEnumerator Coroutine()
    {
        yield break;
    }

}