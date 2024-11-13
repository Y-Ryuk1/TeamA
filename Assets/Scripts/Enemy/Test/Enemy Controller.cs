using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform player;
    [SerializeField] public float speed = 5f; // �G�̈ړ����x
    [SerializeField] public float chaseDistance = 10f; // �v���C���[��ǂ������鋗��

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (player == null) return;

        // �v���C���[�Ƃ̋������v�Z
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // �v���C���[�����̋����ȓ��ɂ���ꍇ
        if (distanceToPlayer < chaseDistance)
        {
            // �v���C���[�̕���������
            Vector3 direction = (player.position - transform.position).normalized;

            // �G���v���C���[�Ɍ������Ĉړ�
            transform.position += direction * speed * Time.deltaTime;

            // �G���v���C���[������
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
