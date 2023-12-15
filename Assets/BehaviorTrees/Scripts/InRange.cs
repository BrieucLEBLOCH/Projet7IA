using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class InRange : ActionNode
{
    private Player player;
    private Rigidbody2D rb2d;
    Vector2 range;
    protected override void OnStart() {
        player = GameObject.Find("/Player").GetComponent<Player>();
        rb2d = context.gameObject.GetComponent<Rigidbody2D>();
        range = new Vector2(50, 50);

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        /*if ((player.transform.position - rb2d.position) == range)
        {
            return State.Success;
        }*/
        return State.Failure;
    }
}
