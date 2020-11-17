using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerIG : MonoBehaviour
{
    enum mSkill
    {
        mAttack,
        mSkill_Fire,
        mSkill_Ice,
        mSkill_Heal
    } 

    mSkill mPlayerSkill;


    [SerializeField]
    private GameObject attackPoint;

    Animation mAnim;
    public int mHp = 20;
    public int mSpeed = 3;
    private float mMove = 0f;

    private bool mIsIdle = false;
    private bool mIsWalk = false;
    private bool mIsDeath = false;

   

    void Start()
    {
        UIEventToInGame.Instance.EventStickMove += OnEventMove;
        UIEventToInGame.Instance.EventStickUp += OnEventStop;
        mAnim = GetComponent<Animation>();
        
      
        mAnim.CrossFade("free", 0.2f);
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            skillAttack();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            skillFire();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            skillIce();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            skillHeal();
        }
        //switch(mPlayerSkill)
        //{
        //    case 0:
        //        mAnim.CrossFade("attack", 0.2f);
        //        break;
        //    case 1 , 2:
        //        mAnim.CrossFade("skill", 0.2f);
        //        break;
        //    case 3:
        //        mAnim.CrossFade("skill", 0.2f);
        //        break;
        //}

        //if (mPlayerSkill == 0)
        //{
        //    mAnim.CrossFade("attack", 0.2f);
        //}

        //if (mPlayerSkill == 1)
        //{
        //    mAnim.CrossFade("skill", 0.2f);
        //}

        if (mIsDeath)
        {
            mAnim.CrossFade("death", 0.2f);
        }
    }

    private void skillAttack()
    {
        mAnim.CrossFade("attack", 0.2f);
        var bullet = ObjectPoolIG.GetObject();
        bullet.transform.position = attackPoint.transform.position;
       
        bullet.Shoot(transform.forward * 10f);
    }

    private void skillFire()
    {
        StartCoroutine(CoroutinSkill_Fire());
    }
    private void skillIce()
    {
        StartCoroutine(CoroutinSkill_Ice());
    }
    private void skillHeal()
    {
        StartCoroutine(CoroutinSkill_Heal());
    }

    private void OnDestroy()
    {
        UIEventToInGame.Instance.EventStickMove -= OnEventMove;
        UIEventToInGame.Instance.EventStickUp -= OnEventStop;
    }

    void OnEventMove(Vector2 direction)
    {
        Vector3 worldDirection = new Vector3(direction.x, 0f, direction.y);
        transform.Translate(worldDirection.normalized * mSpeed * Time.deltaTime, Space.World);
        mIsWalk = true;

        if(direction.x != 0 || direction.y != 0)
        {
            Quaternion q = Quaternion.LookRotation(worldDirection);
            float y = q.eulerAngles.y;
            transform.rotation = Quaternion.Euler(new Vector3(0, y, 0));
        }
    }

    void OnEventStop(bool walk)
    {
        if (walk)
        {
            mIsIdle = false;
            mIsWalk = true;
        }
        else if (walk != true)
        {
            mIsWalk = false;
            mIsIdle = true;
        }
    }

    IEnumerator CoroutinSkill_Fire()
    {
        mAnim.CrossFade("skill", 0.2f);
        var skill_FireBox = ObjectPoolIG.GetFireObject();
        skill_FireBox.transform.position = transform.Find("Skill_Fire").position;
        skill_FireBox.Shoot(transform.position + transform.forward * 10f);
       
        yield return new WaitForSeconds(3f);
        
    }

    IEnumerator CoroutinSkill_Ice()
    {
        mAnim.CrossFade("skill", 0.2f);
        var skill_IceBox = ObjectPoolIG.GetIceObject();
        skill_IceBox.transform.position = transform.Find("Skill_Ice").position;
        skill_IceBox.Shoot(transform.position + transform.forward * 10f);

        yield return new WaitForSeconds(3f);

    }

    IEnumerator CoroutinSkill_Heal()
    {
        mAnim.CrossFade("skill", 0.2f);
        var skill_HealBox = ObjectPoolIG.GetHealObject();
        skill_HealBox.transform.position = transform.Find("Skill_Heal").position;
        skill_HealBox.Shoot(transform.position + transform.forward * 10f);
      
        yield return new WaitForSeconds(3f);
      
    }

}

