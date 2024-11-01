using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ability;
public class CandleAppearanceChanger : TestCandleGimmick, IInteractable
{
    private bool _canInteract = true;
    private Renderer _candleRenderer;
    [SerializeField] private GameObject _candleObject = null;
    private void Start()
    {
        _candleRenderer = GetComponent<Renderer>();
        if (_candleObject)
        {
            _candleObject.SetActive(false);
        }
    }
    public bool CanInteract()
    {
        //�v���C���[��������Ȃ����疳�����T���Ă܂�
        //�����F�ʂ̕��@�ł̎Q�Ɓ@�v�C��
        _canInteract = FindAnyObjectByType<PlayerStatus>().GetComponent<PlayerStatus>().Ability is SurtrCaptrable ? true : false;
        return _canInteract;
    }

    public string GetInteractionMessage()
    {
        return "�΂𓔂�";
        /*
        return "�����ڕς��܂�";
        */
    }

    public void OnInteract(IInteractCallBackReceivable caller)
    {
        if (_canInteract)
        {
            base.ClearActive();
            if (_candleObject)
            {
                _candleObject.SetActive(true);
            }
            //_candleRenderer.material.color = Color.red;
            _canInteract = false;
        }
        else
        {
            Debug.Log("�����΂�����΁c�c");
        }
    }
}
