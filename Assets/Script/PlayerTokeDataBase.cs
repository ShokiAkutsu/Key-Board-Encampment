using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTokeDataBase : MonoBehaviour
{
    InputState _inputState;
    //�ǂ��̃L�[�ɂ���̂�
    //�ꏊ�̊i�[��KeyTileDataBase���ȁH
    //��Ƃ�ID����U���āA�����I�𒆂̎��I���ł��Ȃ��悤�ɂ���Ƃ�
    //��̏ꏊ����אڂ��Ă����瓮����悤�ɂ�����
    //�����āA��𓮂�������
    //���World���W�n�ɒ����Ȃ��Ƃ���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum InputState
{
	Idle,
	Selecting,
	Confirming,
	Resolving
}