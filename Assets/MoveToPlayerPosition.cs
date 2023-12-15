using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using Unity.VisualScripting;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MoveToPlayerPosition : ActionNode
{
    private Player player;
    [SerializeField] private float moveSpeedMonster = 1f;
    private Rigidbody2D rb2d;

    protected override void OnStart() {
        player = GameObject.Find("/Player").GetComponent<Player>();
        rb2d = context.gameObject.GetComponent<Rigidbody2D>();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (player != null)
        {
            Vector2 direction = (player.transform.position - context.gameObject.transform.position).normalized;
            rb2d.MovePosition(rb2d.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
        }
        return State.Success;
    }
}
