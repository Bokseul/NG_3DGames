﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGoblin : MonsterAI
{
    public override void SetState()
    {
        mStates[0] = new State_Idle();
        mStates[1] = new State_Skill1();
        mStates[2] = new State_Trace();
        mStates[3] = new State_NomalAttack();
        mStates[4] = new State_Damaged();
        mStates[5] = new State_Die();
    }
}
