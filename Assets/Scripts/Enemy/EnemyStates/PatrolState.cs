/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState {

    private Enemy enemy;

    private Vector3 patrolLocation;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;

        enemy.Anim.SetInteger("speed", 1);
    }

    public void Execute()
    {
        if (enemy.target != null && enemy.inMeleeRange)
        {
            enemy.ChangeState(new MeleeState());
        }

    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider o)
    {
    }

    private void Patrol()
    {

        
    }
}
