using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    public float maxHp = 4;
    private float currentHp;
    private Enemy enemy;
    private SpriteRenderer spriteRender;

    public float MaxHP => maxHp;
    public float CurrentHP => currentHp;

    private void Awake()
    {
        currentHp = maxHp;
        enemy = GetComponent<Enemy>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent("Bullet"))
            return;

        maxHp -= collision.GetComponent<Bullet>().damage;

        if (maxHp > 0)
        {

        }
        else
        {
            Dead();
        }
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //}
}
