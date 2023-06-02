using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float detectionRange = 7f;
    public string ETag = "Enemy";

    private Transform TurretTransform;
    private Transform nearestEnemyTransform;
    private bool WaEnemy = false;

    
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    public float curtime;

    void Update()
    {

        if (curtime <= 0)
        {
            if (!WaEnemy)
            {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(TurretTransform.position, detectionRange);
                float nearestEnemyDistance = Mathf.Infinity;

                foreach (Collider2D enemy in enemies)
                {
                    if (enemy.CompareTag(ETag))
                    {
                        float distanceToEnemy = Vector2.Distance(TurretTransform.position, enemy.transform.position);
                        if (distanceToEnemy < nearestEnemyDistance)
                        {
                            nearestEnemyDistance = distanceToEnemy;
                            nearestEnemyTransform = enemy.transform;
                        }
                    }
                }

                if (nearestEnemyTransform = null)
                {
                    WaEnemy = true;
                }
            }

            if (WaEnemy)
            {
                Instantiate(bullet, pos.position, transform.rotation);
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
