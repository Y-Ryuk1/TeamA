using Alchemy.Inspector;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [LabelText("�G�l�~�[�̃v���n�u")]
    [SerializeField] private GameObject _enemyPrefab;

    public GameObject EnemyPrefab => _enemyPrefab;

    [LabelText("��������� / -1��I�ԂƖ����ɐ���")]
    [SerializeField] private int _mamGenerateCnt = 0;
    public int MaxGenerateCnt => _mamGenerateCnt;

    [LabelText("�V�[���ɑ��݂ł���ő吔")]
    [SerializeField] private int _maxEnemyCnt = 0;
    public int MaxEnemyCnt => _maxEnemyCnt;

    [LabelText("�G�l�~�[�̋���")]
    [SerializeField, SerializeReference] private IMovePatternEnemy _movePatern;
    public IMovePatternEnemy MovePatern => _movePatern;
}

public interface IMovePatternEnemy 
{
    public (Vector3 position, Vector3 direction) NextTarget();
    public UniTask NextTargetActionAsync(Quaternion rotation, Transform transform, CancellationToken token);
}