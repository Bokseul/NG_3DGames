using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_NomalAttack : State
{
    public override void Enable()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
            mMonsterAnimator.SetTrigger("triggerAttack1");
        else
            mMonsterAnimator.SetTrigger("triggerAttack2");
    }

    public override void Update()
    {
    }

    public override IEnumerator Coroutine()
    {
        yield break;
    }
}
