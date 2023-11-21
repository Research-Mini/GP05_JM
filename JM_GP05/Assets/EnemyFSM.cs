using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{

    public enum EnemyState { GoToBase, AttackBase, RangeAttack }

    public EnemyState currentState;

    float lastShootTime;
    UnityEngine.AI.NavMeshAgent agent;
    public Transform baseTransform;

    public GameObject bulletPrefab;
    public float fireRate;
    public Sight sightSensor;
    public float baseAttackDistance;
    public float playerAttackDistance;
    private float attackStartTime;
    void Awake()
    {
        baseTransform = GameObject.Find("LoseBase").transform;
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (currentState == EnemyState.GoToBase)
            GoToBase();
        else if (currentState == EnemyState.AttackBase)
            AttackBase();
        else if (currentState == EnemyState.RangeAttack)
            RangeAttack();
       
    }


    void GoToBase()
    {
        agent.isStopped = false;

        agent.SetDestination(baseTransform.position);

        if (sightSensor.detectedObject != null)
            currentState = EnemyState.RangeAttack;

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase <= baseAttackDistance)
            currentState = EnemyState.AttackBase;
    }


    void RangeAttack()
    {
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer <= playerAttackDistance * 2)
        {
            if (!agent.isStopped)
            {
                agent.isStopped = true; // 처음 멈추면 시간 기록
                attackStartTime = Time.time;
            }

            if (Time.time - attackStartTime < 2.0f) // 2초 동안 멈춤
            {
                LookTo(sightSensor.detectedObject.transform.position);
                Shoot();
            }
            else
            {
                agent.isStopped = false; // 2초 후 움직임 재개
                currentState = EnemyState.GoToBase; // 다음 행동 결정
            }
        }
        else
        {
            currentState = EnemyState.GoToBase;
        }
    }

    void AttackBase()
    {
        agent.isStopped = true;
        LookTo(baseTransform.position);
        Shoot();
    }

    void LookTo(Vector3 targetPosition)
    {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition - transform.parent.position);
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }

    void Shoot()
    {
        var timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot < fireRate)
            return;

        lastShootTime = Time.time;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }
}