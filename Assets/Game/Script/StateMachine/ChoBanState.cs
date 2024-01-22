using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoBanState : IState
{
    public void OnEnter(GameManager gM)
    {
        gM.currentEnumState = State.CHOBAN;
    }

    public void OnExecute(GameManager gM)
    {
        
    }

    public void OnExit(GameManager gM)
    {
        
    }
}
