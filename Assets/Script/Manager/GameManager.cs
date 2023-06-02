using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    
    public float gameTime;
    public float maxGameTime = 2 * 10f;


    public PoolManager pool;
    public PlayerMoving playe;

    private void Awake()
    {
        manager = this;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}
