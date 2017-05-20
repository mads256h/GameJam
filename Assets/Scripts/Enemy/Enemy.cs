﻿/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;


[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Enemy : Character {



    private IEnemyState currentState;

    [SerializeField]
    private float meleeRange = 2;

    public float meleeCooldown = 2, attackDamage;

    public bool randomPos = true;

    private float damageTimer, damageCooldown = 0.25f;

	[HideInInspector]
    public UnityEngine.AI.NavMeshAgent agent;

    [HideInInspector]
    public bool isAttacking, canMove = true;

    public void setAttackingToFalse()
    {
        isAttacking = false;
    }

    public bool inMeleeRange
    {
        get
        {
            if(meleeRange == 0)
            {
                return false;
            }

            if (target != null)
            {
                return Vector3.Distance(transform.position, target.transform.position) <= meleeRange;
            }

            return false;
        }
    }

    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    public override void Start()
    {
        base.Start();

        if(players == null || players.Length != 2)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }

        if (randomPos)
            transform.position = newPoint();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ChangeState(new HuntState());

        WaveSystem.currentEnemies++;
    }

    void Update()
    {

        float disToPlayer1 = Vector3.Distance(transform.position, players[0].transform.position);
        float disToPlayer2 = Vector3.Distance(transform.position, players[1].transform.position);


        if (disToPlayer1 > disToPlayer2)
        {
            target = players[1];
        }
        else
        {
            target = players[0];
        }

        if(players[0].GetComponent<Player>().isDead)
        {
            target = players[1];
        }

        if (players[1].GetComponent<Player>().isDead)
        {
            target = players[0];
        }

        if (!IsDead)
        {
            if(!takingDamage)
            {
                currentState.Execute();
            }

            for (int i = 0; i < agent.path.corners.Length - 1; i++)
            {
                Debug.DrawLine(agent.path.corners[i], agent.path.corners[i + 1], Color.green);
            }

        }
        else
        {
            if(damageCollider != null)
                damageCollider.enabled = false;
        }

    }

    public void ChangeState(IEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
        Debug.Log("New state: " + currentState);

    }

    public override void OnTriggerEnter(Collider o)
    {
        base.OnTriggerEnter(o);
        currentState.OnTriggerEnter(o);

        if(o.tag == "Player" && !IsDead)
        {
            Debug.Log("Player took " + attackDamage + " damage");
            o.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }

    public void OnTriggerStay(Collider o)
    {
        damageTimer += Time.deltaTime;

        if(damageTimer > damageCooldown)
        {
            if (o.tag == "Player")
            {
                Debug.Log("Player took " + attackDamage + " damage");
                o.GetComponent<Player>().TakeDamage(attackDamage);
                damageTimer = 0;
            }
        }
    }

    public override IEnumerator TakeDamage(int amount)
    {

        Debug.Log("took " + amount + " damage");

        if(!IsDead)
        {
            health -= amount;
            if (IsDead)
            {
                canMove = false;
                //Anim.SetTrigger("death");


                WaveSystem.currentEnemies--;
                Destroy(gameObject,30);
                GetComponentInChildren<SpriteRenderer>().color = new Color32(139, 61, 61, 255);
                GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
                agent.enabled = false;
                Destroy(GetComponent<AudioSource>());
            }
            else
            {
                canMove = false;
                Anim.SetTrigger("damage");

            }

        }
        yield return null;
    }


    #region navmesh agent
    public void MoveToward(Vector3 point)
    {
        if (!isAttacking && !IsDead && canMove)
        {
            agent.SetDestination(point);
            agent.isStopped = false;
        }
        else
        {
            agent.isStopped = true;
        }
           


       
    }

    public bool hasPath()
    {
        return agent.hasPath;
    }

    public Vector3 newPoint()
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * 200;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, 200, 1);
        return hit.position;
    }

    public void LookAt(Transform t)
    {

        Quaternion rotation = Quaternion.LookRotation(t.position - transform.position);
        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    public void SetCanMoveToTrue()
    {
        canMove = true;
    }

    public void StopAnimation()
    {
        Anim.speed = 0;
    }

    #endregion
}

