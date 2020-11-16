using UnityEngine;

public class UIEventToInGame : Singleton<UIEventToInGame>
{
    public event System.Action<Vector2> EventStickMove; // 조이스틱 방향에 관한 정보
    public event System.Action<bool> EventStickUp;      // 조이스틱을 놨을때
    public event System.Action<int> EventSkillBtn;      // 스킬무엇을 눌렀지?
    public event System.Action<bool> EventIceSkillBtn;  // 아이스 스킬의 누름의 여부

    public event System.Action EventSkillUp;

    public void OnEventStickMove(Vector2 direction)
    {
        if (EventStickMove != null)
            EventStickMove(direction);
    }

    public void OnEventStickUp(bool stickup)
    {
        if (EventStickUp != null)
            EventStickUp(stickup);
    }

    public void OnEventIceSkillBtn(bool iceskill)
    {
        if (EventIceSkillBtn != null)
            EventIceSkillBtn(iceskill);
    }

    public void OnEventSkillBtn(int skillbtnCollet)
    {
        if (EventSkillBtn != null)
            EventSkillBtn(skillbtnCollet);
    }

    public void OnEventBtnUp()
    {
        if (EventSkillUp != null)
            EventSkillUp();
    }
}
