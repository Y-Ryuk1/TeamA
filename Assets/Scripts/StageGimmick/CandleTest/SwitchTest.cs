using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTest : MonoBehaviour
{
    private bool _hasProcessed = false;
    private float _rayDistance = 1f;
    private float _switchDistance = 2f;
    [SerializeField] private Vector3 _halfExtents; //�X�C�b�`�̑傫���̔��a
    private Vector3 _switchCenterOffset = new Vector3(0, 0.5f, 0);
    public event Action OnSwitchPressed; //�h�A�J�ʒm
    private void FixedUpdate()
    {
        if (_hasProcessed || !gameObject) return;

        if (IsPlayerOnSwitch())
        {
            OnSwitchPressed?.Invoke();
            _hasProcessed = true;
        }
    }
    private bool IsPlayerOnSwitch()
    {
        return Physics.BoxCast(transform.position + new Vector3(0, -0.5f, 0), _halfExtents, Vector3.up, out RaycastHit hit, Quaternion.identity, _switchDistance);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.up, _halfExtents + new Vector3(0, _switchDistance, 0));
    }
}
