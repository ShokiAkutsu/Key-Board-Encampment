using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKeyManager : MonoBehaviour
{
    //�v���C���[�̏����L�[�ʒu
    string _p1keyName;
    string _p2keyName;

    public string P1KeyName => _p1keyName;
    public string P2KeyName => _p2keyName;

    // Start is called before the first frame update
    void Start()
    {
        char _p1 = (char)('A' + Random.Range(0, 26));
        char _p2 = (char)('A' + Random.Range(0, 26));
        
        _p1keyName = _p1.ToString();
        _p2keyName = _p2.ToString();

        if(_p1keyName == _p2keyName)
        {
            //�E�[�X�^�[�g�ɂ���
            if (_p1keyName != "P") _p2keyName = "P";
            //P1��P�Ȃ�Ό���"Z"�ɂ���
            else _p2keyName = "Z";
        }
	}
}
