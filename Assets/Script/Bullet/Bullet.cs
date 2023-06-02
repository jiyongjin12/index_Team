using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public int damage = 1;

    public float speed;

    private void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);   
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyHp>();
        Destroy(gameObject);
    }
}
