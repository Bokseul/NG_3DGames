using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonsterAI
{
    [SerializeField]
    GameObject mBuffFxPrf;
    GameObject BuffFX_Self;
    GameObject[] BuffFXs;

    [SerializeField]
    GameObject Skill1FXPrf;
    GameObject Skill1FX_Self;

    [SerializeField]
    Transform target;

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
        mStates[4] = new State_Move();
        mStates[5] = new State_Buff();
        mStates[6] = new State_Skill1();
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

    void SkillFX1()
    {
        if (mCurrState == mStates[5])
        {
            BuffFX_Self = Instantiate(mBuffFxPrf, transform.position, transform.rotation);
        }

        if (mCurrState == mStates[6])
        {
            Skill1FXPrf = Instantiate(Skill1FXPrf, target.position, target.rotation);
        }
    }

    void SkillFX2()
    {
        ChangeState(mStates[1]);
    }
}