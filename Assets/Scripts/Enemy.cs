using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
[SerializeField]
private float attackRefreshRate = .5f;

private AggroDetection aggroDetection;
private Health healthTarget;
private float attackTimer;
    private void Awake()
    {

        aggroDetection =GetComponent<AggroDetection>();
    }
    private void AggroDetection_OnAggro(Transform target)
    {
        Health health= target.GetComponent<Health>();
        if (health != null)
        {
          healthTarget = health;

        }
    }
     private void Update()
    {
        if (healthTarget != null)
        {
           attackTimer += Time.deltaTime;

            if (CanAttack())
            {
               Attack();
            }
        }
    }

    private bool CanAttack()
    {
     return attackTimer >= attackRefreshRate;
     
    }
    private void Attack()
    {

       attackTimer = 0;
       healthTarget.TakeDamage(1);
    }
    }

