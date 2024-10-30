using Alchemy.Inspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleAppearanceChanger : TestCandleGimmick, IInteractable
{
    private bool _canInteract = true;
    private Renderer _candleRenderer;
    [SerializeField] private GameObject _candleObject = null;


    [LabelText("�΂����Ă����Ԃ�������")]
    [SerializeField] private bool _isFiredCorrect = true;

    /// <summary>
    /// ���݁A�΂����Ă��邩���Ǘ�����u�[��
    /// </summary>
    private bool _isFire = false;

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
        return _canInteract ? "�΂𓔂�" : "�΂������...";
    }

    public void OnInteract(IInteractCallBackReceivable caller)
    {
        if (_canInteract)
        {
            base.ClearActive(_isFiredCorrect ? _isFire : !_isFire);
            if (_candleObject)
            {
                _candleObject.SetActive(!_isFire);
                _isFire = !_isFire;
            }
            _canInteract = false;
        }
        else
        {
            Debug.Log("�����΂�����΁c�c");
        }
    }
}
