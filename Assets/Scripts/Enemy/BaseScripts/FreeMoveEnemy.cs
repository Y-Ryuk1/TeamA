using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

//未実装

[Serializable]
/// <summary>自由に動き回るやつ</summary>
public sealed class FreeMoveEnemy : IMovePatternEnemy
{

    Vector3[] IMovePatternEnemy.GetAllTargets()
    {
        return new Vector3[] { Vector3.zero };
    }
    public (Vector3 position, Vector3 direction) GetNextTarget()
    {
        return (Vector3.zero, Vector3.zero);
    }

    public async UniTask NextTargetActionAsync(Quaternion rotation, Transform transform, CancellationToken token)
    {
        await UniTask.Delay(10);
        Debug.Log("Still this Method Undifined");
    }
}