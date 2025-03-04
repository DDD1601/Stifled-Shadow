﻿using UnityEngine;

public class NightBornStunnedState : EnemyState
{

    private Enemy_NightBorn enemy;
    public NightBornStunnedState(Enemy _enemyBase, EnemyStateMachine _startMachine, string _animBoolName, Enemy_NightBorn _enemy) : base(_enemyBase, _startMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }
    public override void Enter()
    {
        base.Enter();

        enemy.fx.InvokeRepeating("RedColorBlink", 0, .1f);//chay lap lai sau moi .1f

        stateTimer = enemy.stunDuration;

        rb.linearVelocity = new Vector2(-enemy.facingDir * enemy.stunDirection.x, enemy.stunDirection.y);
    }

    public override void Exit()
    {
        base.Exit();

        enemy.fx.Invoke("CancelColorChange", 0);
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.idleState);
    }

}