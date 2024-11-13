using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform player;
    [SerializeField] public float speed = 5f; // 敵の移動速度
    [SerializeField] public float chaseDistance = 10f; // プレイヤーを追いかける距離

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (player == null) return;

        // プレイヤーとの距離を計算
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // プレイヤーが一定の距離以内にいる場合
        if (distanceToPlayer < chaseDistance)
        {
            // プレイヤーの方向を向く
            Vector3 direction = (player.position - transform.position).normalized;

            // 敵をプレイヤーに向かって移動
            transform.position += direction * speed * Time.deltaTime;

            // 敵がプレイヤーを向く
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
