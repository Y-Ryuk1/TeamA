using System;
using UnityEngine;

//未実装

[Serializable]
/// <summary>自由に動き回るやつ</summary>
public sealed class FreeMoveEnemy : IMovePatternEnemy
{

    public (Vector3 position, Vector3 direction) NextTarget()
    {
        return (Vector3.zero, Vector3.zero);
    }
}