using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveAwayFromPlayer : ActionNode
{
    private Player player;
    [SerializeField] private float moveSpeedMonster = 1f;
    private Rigidbody2D rb2d;

    protected override void OnStart()
    {
        player = GameObject.Find("/Player").GetComponent<Player>();
        rb2d = context.gameObject.GetComponent<Rigidbody2D>();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        Debug.Log("bite");
        float range = (player.transform.position - context.gameObject.transform.position).magnitude;
        Debug.Log(range);
        if (player != null && range <= 6)
        {
            Vector2 direction = (player.transform.position - context.gameObject.transform.position).normalized;
            rb2d.MovePosition(-(rb2d.position + direction * moveSpeedMonster * Time.fixedDeltaTime));
        }
        return State.Success;
    }
}
