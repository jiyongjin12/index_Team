using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2 : MonoBehaviour
{
    public float rotationSpeed = 60f;
    public float detectionRange = 7f; // ���� ����
    public string enemyTag = "Enemy";

    private Transform TurretTransform;
    private Transform nearestEnemyTransform;
    private bool isChasingEnemy = false;

    private void Start()
    {
        TurretTransform = transform;
    }

    private void Update()
    {
        // �� ����
        if (!isChasingEnemy)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(TurretTransform.position, detectionRange);
            float nearestEnemyDistance = Mathf.Infinity;

            foreach (Collider2D enemy in enemies)
            {
                if (enemy.CompareTag(enemyTag))
                {
                    float distanceToEnemy = Vector2.Distance(TurretTransform.position, enemy.transform.position);
                    if (distanceToEnemy < nearestEnemyDistance)
                    {
                        nearestEnemyDistance = distanceToEnemy;
                        nearestEnemyTransform = enemy.transform;
                    }
                }
            }

            if (nearestEnemyTransform != null)
            {
                isChasingEnemy = true;
            }
        }

        // ȸ�� �� ����
        if (isChasingEnemy)
        {
            Vector2 direction = nearestEnemyTransform.position - TurretTransform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            TurretTransform.rotation = Quaternion.RotateTowards(TurretTransform.rotation, targetRotation, rotationSpeed * 3f *Time.deltaTime);

            // �ʱ�ȭ
            float distanceToNearestEnemy = Vector2.Distance(TurretTransform.position, nearestEnemyTransform.position);
            if (distanceToNearestEnemy > detectionRange)
            {
                isChasingEnemy = false;
                nearestEnemyTransform = null;
            }
        }
        else
        {
            TurretTransform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
