using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;
    //public float health;
    //public float maxHealth;

    //bool isLive;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexVec);
        rigid.velocity = Vector2.zero;
    }

    private void OnEnable()
    {
        target = GameManager.manager.playe.GetComponent<Rigidbody2D>();
        //isLive = true;
        //health = maxHealth;
    }

    //public void Init(SpawnData data)
    //{
    //    speed = data.speed;
    //    maxHealth = data.health;
    //    health = data.health;
    //}







    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!collision.CompareTag("Bullet"))
    //        return;

    //    health -= collision.GetComponent<Bullet>().damage;

    //    if (health > 0)
    //    {

    //    }
    //    else
    //    {
    //        Dead();
    //    }
    //}

    //void Dead()
    //{
    //    gameObject.SetActive(false);
    //}
}
