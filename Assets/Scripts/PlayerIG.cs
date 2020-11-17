using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerIG : MonoBehaviour
{
    Animation mAnim;
    public int mHp = 20;
    public int mSpeed = 10;
    private float mMove = 0f;

    private bool mIsIdle = false;
    private bool mIsWalk = false;
    private bool mIsAttack = false;
    private bool mIsSkill = false;
    public bool mIsDeath { get; private set; } = false;

    void Start()
    {
        UIEventToInGame.Instance.EventStickMove += OnEventMove;
        mAnim = GetComponent<Animation>();
    }

    void Update()
    {
        if(mIsIdle)
        {
            mAnim.CrossFade("free", 0.2f);
        }

        if (mIsWalk)
        {
            mAnim.CrossFade("walk", 0.2f);
        }

        if (mIsAttack)
        {
            mAnim.CrossFade("attack", 0.2f);
        }

        if (mIsSkill)
        {
            mAnim.CrossFade("skill", 0.2f);
        }

        if (mIsDeath)
        {
            mAnim.CrossFade("death", 0.2f);
        }
    }

    private void OnDestroy()
    {
        UIEventToInGame.Instance.EventStickMove -= OnEventMove;
    }

    void OnEventMove(Vector2 direction)
    {
        Vector3 worldDirection = new Vector3(direction.x, 0f, direction.y);
        transform.Translate(worldDirection.normalized * mSpeed * Time.deltaTime, Space.World);
        mIsWalk = true;
    }
}

