using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject Explosion;
    GameController gameController;

    float offset;
    void Start()
    {
        offset = Random.Range(0, 2f * Mathf.PI);
        // .GetComponent<GameController>()はGameControllerのなかのさらにスクリプトを取得している。
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        
    }

    void Update()
    {
        transform.position -= new Vector3(
            Mathf.Cos(Time.frameCount * 0.05f + offset) * 0.01f,
            Time.deltaTime,
            0
            );
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }

    // 当たり判定をお香なうには
    // ・両者にcolliderがついている
    // ・どちらかにRigitbodyがついている

    // isTriggerにチェックをつけた場合はこちらが実行
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {
            Instantiate(Explosion, collision.transform.position, transform.rotation);
            gameController.GameOver();
        }
        else if (collision.CompareTag("Bullet") == true)
        {
            gameController.AddScore();
        }
        
        Destroy(gameObject);
        Destroy(collision.gameObject);
        Instantiate(Explosion, transform.position, transform.rotation);
        


    }
    private void OnCollisionEnter2D(Collider2D collision)
    {

    }
}
