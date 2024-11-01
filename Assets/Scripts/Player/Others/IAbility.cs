using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ability
{
    //�v���C���[�̃A�r���e�B(�X�L��)�𒊏ۓI�Ɉ������߂�interface�ł�
    public interface IPlayerAbility 
    {
        /// <summary>
        /// ���݂�Ability��NoneAbility(�A�r���e�B���ݒ肳��Ă��Ȃ����)�łȂ��Ƃ�true��Ԃ�masu
        /// </summary>
        /// <returns></returns>
        bool HasAbility() { return true; }

        /// <summary>
        /// �ݒ肳�ꂽ�A�r���e�B�����s���܂�
        /// </summary>
        [Obsolete()]
        void PerformAbility();

        /// <summary>
        /// �A�r���e�B�g�p���A���̊֐����Ă΂ꂽ���Player�̃X�e�[�g���߂�l�ɐ؂�ւ��܂�
        /// </summary>
        /// <param name="performer"></param>
        /// <returns></returns>
        PlayerBaseState OnPerformAbility(GameObject performer) { return null; }
    }
    //�Ȃ�̃A�r���e�B���ݒ肳��Ă��Ȃ����Ƃ�\��Ability�ł�
    public sealed class NoneAbility : IPlayerAbility
    {
        public bool HasAbility() { return false; }

        public PlayerBaseState OnPerformAbility(GameObject performer){ return null; }

        public void PerformAbility() { }
    }

    //�e�X�g�p
    [Serializable]
    public class CandleAbility : IPlayerAbility
    {
        public PlayerBaseState OnPerformAbility(GameObject performer)
        {
            throw new NotImplementedException();
        }

        public void PerformAbility()
        {
            Debug.Log("CandleAbility���ݒ肳��Ă��܂�");
        }
    }
}


