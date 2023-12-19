using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CanSpawnMonsters : ActionNode
{
    bool isCooldown;
    protected override void OnStart() {

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        isCooldown = context.transform.GetComponent<SpawnCD>().IsCooldown();
        if(isCooldown ) 
        {
            return State.Failure;
        }
        return State.Success;


    }
}
