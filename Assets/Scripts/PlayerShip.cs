using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public Transform firePoint; //弾の位置情報を取得
    public GameObject Bullet;

    AudioSource audioSource;
    public AudioClip shotSE;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 4f;
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -2.9f, 2.9f),
            Mathf.Clamp(nextPosition.y, -2f, 2f),
            nextPosition.z
            );

        transform.position = nextPosition;
    }

    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, firePoint.position, transform.rotation);
            audioSource.PlayOneShot(shotSE);
        }
    }
        
    
}

// PlayerShipの頭に弾発射するエリアをつくる
// 弾が上にまっすぐ飛んでいくスクリプトを書いてアタッチ
// スペースキーを押したら無限に弾が生成されるスクリプト