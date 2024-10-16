using System;
using UnityEngine;

[Serializable]
/// <summary>巡回するやつ</summary>
public sealed class PatrolEnemy : IMovePatternEnemy
{
    [SerializeField] private Transform[] _patrolPositions;

    private Action MoveEnemyPatrol;
}
