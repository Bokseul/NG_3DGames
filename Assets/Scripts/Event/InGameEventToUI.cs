public class InGameEventToUI : Singleton<InGameEventToUI>
{
    public event System.Action<bool> EventAniDone;

    public void OnEventAniDone(bool aniFinish)
    {
        if (EventAniDone != null)
            EventAniDone(aniFinish);
    }
}
