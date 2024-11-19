using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinecartState
{
    protected MinecartStateController msc;
     public abstract void CheckTransitions();

    public abstract void Act();

    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateExit()
    {

    }
    public MinecartState(MinecartStateController msc)
    {
        this.msc = msc;
    }
}

