using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelSkillUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject mObj_Ice;
    public int mBtn_num;
    public bool mBtn_skill;

    // atk = 0 | skill_fire = 1 | skill_ice = 2 | skill_heal = 3

    public bool mAttack_UiBtn;
    public bool mSkill_UiBtn;
    public bool mHeal_UiBtn;

    public bool mIceSkill_btn = false;

    private void Awake()
    {
        mObj_Ice = GameObject.Find("Skill_Icon_Ice");

        mBtn_num = 0;
        mBtn_skill = false;

        mAttack_UiBtn = false;
        mSkill_UiBtn = false;
        mHeal_UiBtn = false;
    }
    
    private void Update()
    {
        if (mObj_Ice)
        {
            IceSkill_Btn(mIceSkill_btn);
        }
        if (mBtn_skill)
        {
            GetSkillInputInfo(out mBtn_num);
            OnClickSkill_btn(mBtn_num);
        }
    }

    private void GetSkillInputInfo(out int mBtn_num)
    {
        mBtn_num = 1;
    }

    private void OnClickSkill_btn(int mBtn_num)
    {
        UIEventToInGame.Instance.OnEventSkillBtn(mBtn_num);
    }

    private void IceSkill_Btn(bool mIceSkill_btn)
    {
        mIceSkill_btn = true;
    }

    private void Update_IceSkill(PointerEventData eventData = null)
    {

    }

    public void EventAttackBtn()
    {
        mAttack_UiBtn = true;
        Debug.Log(mAttack_UiBtn);
    }

    public void EventSkillBtn()
    {
        mSkill_UiBtn = true;
    }

    public void EventHealBtn()
    {
        mHeal_UiBtn = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UIEventToInGame.Instance.OnEventIceSkillBtn(mIceSkill_btn);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mSkill_UiBtn = false;
        UIEventToInGame.Instance.OnEventBtnUp();
    }

    
}