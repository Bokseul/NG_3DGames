using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventToInGame : Singleton<UIEventToInGame>
{
    public event System.Action<Vector2> EventStickMove;
    public event System.Action EventStickUp;

    public void OnEventStickMove(Vector2 direction)
    {
        if (EventStickMove != null)
            EventStickMove(direction);
    }
    public void OnEventStickUp()
    {
        if (EventStickUp != null)
            EventStickUp();
    }
}
