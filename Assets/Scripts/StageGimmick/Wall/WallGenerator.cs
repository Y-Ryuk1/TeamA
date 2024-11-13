using Alchemy.Inspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    [LabelText("�ǂ̃v���n�u")]
    [SerializeField] private List<WallObject> _wallObjectsPrefab;
    [LabelText("��������v���n�u�̏d��")]
    [SerializeField] private List<float> _wallObjectWeight;
    [LabelText("�����ʒu")]
    [SerializeField] private Transform _generatePosition;
    [LabelText("�����Ԋu")]
    [SerializeField] private float _generateInterval;
    [LabelText("���������I�u�W�F�N�g����������")]
    [SerializeField] private float _destroyObjectDistance;

    public float DestroyObjectDistance  // public�v���p�e�B�i�ǂݎ���p�j
    {
        get { return _destroyObjectDistance; }
    }
    private bool _isGenerate; //�����X�^�[�g���鏈��
    private float _timer;

    private void Start()
    {
        _isGenerate = false;
    }

    private void Update()
    {
        _timer = Time.deltaTime;
       if ( _wallObjectsPrefab != null && _isGenerate && _timer >= _generateInterval)
       {
            RandomWallGenerate();
            _timer = 0;
       }
    }

    // �ǂ𐶐����鏈��
    private void RandomWallGenerate()
    {
        int objIndex = GetRandomItem();
        if( objIndex != -1 )
        {
            Instantiate(_wallObjectsPrefab[objIndex], _generatePosition);
        }
        else
        {
            Debug.LogWarning("�����Ɏ��s���܂���");
        }
    }

    // �ǂ̃u���n�u�̓Y������Ԃ����\�b�h
    private int GetRandomItem()
    {
        float totalWeight = 0;

        foreach (var weight in _wallObjectWeight)
        {
            totalWeight += weight;
        }

        float randomValue = UnityEngine.Random.Range(0, totalWeight);
        float cumulativeWeight = 0;

        for (int i = 0; i < _wallObjectsPrefab.Count; i++)
        {
            cumulativeWeight += _wallObjectWeight[i];
            if (randomValue <= cumulativeWeight)
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// �����t���O���I���ɂ���
    /// </summary>
    [Button]
    public void OnGenerateFlag()
    {
        _isGenerate = true;
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying) return;

        Gizmos.color = Color.red;
        Gizmos.DrawCube(_generatePosition.position, this.transform.localScale);

        Gizmos.color = Color.blue; // You can choose any color for the line
        Vector3 lineEnd = _generatePosition.position + _generatePosition.forward * _destroyObjectDistance; // Change 5f to your desired line length
        Gizmos.DrawCube(lineEnd, new Vector3(10f, 5f, 1f));
    }
}
