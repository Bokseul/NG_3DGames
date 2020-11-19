using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InGameEventToUI : Singleton<InGameEventToUI>
{
    public event System.Action<bool> EventDie;

    public void OnEventDie(bool die)
    {
        if (EventDie != null)
            EventDie(die);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
