using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObject : MonoBehaviour, IInteractable
{
    
    private void Start()
    {
        
    }

    ///// <summary>
    ///// ���󏈗�
    ///// </summary>
    //private void Collapse()
    //{
    //    //�������ꂽ�u���b�N��Prefab�𐶐�����
    //    Transform breakBlockTransform = Instantiate(_breakBlockPrefab, transform.position, Quaternion.identity);

    //    //���󂵂��e�p�[�c�ɗ͂�������
    //    foreach (Rigidbody rigidbody in breakBlockTransform.GetComponentsInChildren<Rigidbody>())
    //    {
    //        rigidbody.AddExplosionForce(_collapseForce, transform.position + Vector3.up * 0.5f, _collapseRadius);
    //    }

    //    //���󂵂��p�[�c����������
    //    Destroy(breakBlockTransform.gameObject, _collapseDestorySecond);
    //    //���̃u���b�N���폜
    //    Destroy(this.gameObject);
    //}
    public bool CanInteract()
    {
        throw new System.NotImplementedException();
    }

    public string GetInteractionMessage()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(IInteractCallBackReceivable caller)
    {
        throw new System.NotImplementedException();
    }
}
