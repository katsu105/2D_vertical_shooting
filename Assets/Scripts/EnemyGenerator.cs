using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // 繰り返し関数を実行する
        // Spawn関数を2秒後に0.5秒刻みで実行する。
        InvokeRepeating("Spawn", 2f, 0.5f);
    }

    void Spawn()
    {
        Vector3 spawnPotion = new Vector3(
            Random.Range(-2.5f, 2.5f),
            transform.position.y,
            transform.position.z
            );
        
        Instantiate(
            enemyPrefab,         // 生成するオブジェクト
            spawnPotion,         // 生成する位置
            transform.rotation   // 生成時の向き
            );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
