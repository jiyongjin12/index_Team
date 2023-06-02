using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] spawnPosint;
    //public SpawnData[] spawnData;

    float timer;

    private void Awake()
    {
        spawnPosint = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        

        if (timer > 0.2f)
        {
            timer = 0;
            Spawner();
        }
    }

    void Spawner()
    {
        GameObject enemy = GameManager.manager.pool.Get(0);
        enemy.transform.position = spawnPosint[Random.Range(1, spawnPosint.Length)].position;
    }
}

//[System.Serializable]
//public class SpawnData
//{
//    public float spawnTime;

//    public int spriteType;
//    public int health;
//    public float speed;
//}
