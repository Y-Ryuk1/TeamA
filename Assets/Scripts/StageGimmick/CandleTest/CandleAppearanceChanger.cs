using Alchemy.Inspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ability;
using System;
public class CandleAppearanceChanger : MonoBehaviour, IInteractable, IResetable
{
    private bool _canInteract = true;
    private Renderer _candleRenderer;
    [SerializeField] private GameObject _candleObject = null;


    [LabelText("�΂����Ă����Ԃ�������")]
    [SerializeField] private bool _isFiredCorrect = true;

    public bool IsFiredCorrect { get; private set; }

    /// <summary>
    /// ���݁A�΂����Ă��邩���Ǘ�����u�[��
    /// </summary>
    private bool _isFire = false;
    public bool IsFire { get; private set; }

    public event Action OnStateChanged;

    private void Start()
    {
        _candleRenderer = GetComponent<Renderer>();
        if (_candleObject)
        {
            _candleObject.SetActive(false);
        }
        FindAnyObjectByType<GimmickResetManager>().GetComponent<GimmickResetManager>()._resetAction += ResetGimmick;
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
        if(_canInteract)
        {
            if(_isFire)
            {
                return "�΂�����";
            }
            else
            {
                return "�΂𓔂�";
            }
        }
        else
        {
            return "�΂������...";
        }
    }

    public void OnInteract(IInteractCallBackReceivable caller)
    {
        if (_canInteract)
        {
            _isFire = !_isFire;
            SetState(_isFiredCorrect ? _isFire : !_isFire);
            if (_candleObject)
            {
                _candleObject.SetActive(_isFire);
            }
            _canInteract = false;
        }
        else
        {
            Debug.Log("�����΂�����΁c�c");
        }
    }

    /// <summary>
    /// ���E�\�N�̉΂��ύX���ꂽ���ɌĂԊ֐�
    /// </summary>
    /// <param name="newState">�΂̃I���I�t</param>
    public void SetState(bool newState)
    {
        _isFire = newState;
        OnStateChanged?.Invoke(); // �C�x���g�𔭉�
    }/// <summary>
     /// ���Z�b�g�A�N�V�����̒ǉ�
     /// </summary>
    public void RegisterReset()
    {
        try
        {
            FindAnyObjectByType<GimmickResetManager>().GetComponent<GimmickResetManager>()._resetAction += ResetGimmick;
        }
        catch
        {
            Debug.Log($"{this.gameObject.name} can't register ResetGimmick ");
        }
    }
    /// <summary>
    /// �M�~�b�N�̏�Ԃ����Z�b�g����
    /// </summary>
    public void ResetGimmick()
    {
        _isFire = false;
        _candleObject.SetActive(false);
        SetState(_isFiredCorrect ? _isFire : !_isFire);
        Debug.Log($"{this.gameObject.name} reset gimmick");
    }

    /// <summary>
    /// �o�^�������Z�b�g�A�N�V�����̉���
    /// </summary>
    public void CancelletionReset()
    {
        try
        {
            FindAnyObjectByType<GimmickResetManager>().GetComponent<GimmickResetManager>()._resetAction -= ResetGimmick;
        }
        catch
        {
            Debug.Log($"{this.gameObject.name} can't register ResetGimmick ");
        }
    }
    private void OnDisable()
    {
        CancelletionReset();
    }
}
