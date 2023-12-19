using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class InRange : ActionNode
{
    private Player player;
    private Rigidbody2D rb2d;
    float distance;
    float range;
    protected override void OnStart()
    {
        player = GameObject.Find("/Player").GetComponent<Player>();
        rb2d = context.gameObject.GetComponent<Rigidbody2D>();
        range = 50;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        distance = Vector3.Distance(player.transform.position, context.transform.position);
        if (distance >= range)
        {
            Debug.Log("in range");
            return State.Success;
        }
        return State.Failure;
    }
}
