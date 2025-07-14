using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class KeyTileDataBase : MonoBehaviour
{
	//��`
	KeyStandardPositionSO _keyPositionSO;
	[SerializeField] KeyTileDataSO _keyTileDataSO;
	[SerializeField] Canvas _canvas;
	[SerializeField] Text _textAlphabet;
	SpriteRenderer _sr;
	Color _color;
	//�ϐ�
	string _keyName;
	Vector2 _keyPosition;
	KeyTileState _state;
	public string KeyName => _keyName;
	public Vector2 KeyPosition => _keyPosition;
	public Color Color => _color;
	public KeyTileState State => _state;

	
	public void Init(KeyValuePair<string, Vector2> data)
	{
		if(_sr == null)
		{
			_sr = GetComponent<SpriteRenderer>();
		}
		_color = Color.white;

		_keyName = data.Key;
		_keyPosition = data.Value;

		WindowToCanvasRect();
		
        // �����ڍX�V(1, 2P�J���[�ɂ�����A���ɏ�����������)
        this.gameObject.name = _keyName;
		_textAlphabet.text = _keyName;


		//�f�o�b�O�p�@���Ƃŕʃ}�l�[�W���[�ŊǗ�����悤�ɂ���
		if(_keyName == "A")
		{
			_state = KeyTileState.Player_Red;
			_color = _keyTileDataSO.KeyTileStates[_state].KeyColor;
		}
		if(_keyName == "P")
		{
			_state = KeyTileState.Player_Blue;
			_color = _keyTileDataSO.KeyTileStates[_state].KeyColor;
		}

		_sr.color = _color;
	}

	private void WindowToCanvasRect()
	{
		//�Ֆʂɕ\������A���t�@�x�b�g�ƈʒu�����킹��
		Vector3 worldPos = transform.position;
		Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

		RectTransform canvasRect = _canvas.GetComponent<RectTransform>();
		RectTransform labelRect = _textAlphabet.GetComponent<RectTransform>();

		Vector2 localPoint;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(
			canvasRect, screenPos, null, out localPoint);

		labelRect.localPosition = localPoint;
	}

	private void Update()
	{
		
	}

	/// <summary>
	/// KeyTile�̃X�e�[�^�X�̃A�b�v�f�[�g
	/// </summary>
	public void ChangeTileStates(KeyTileDataBase data)
	{
		_state = data._state;
		_color = _keyTileDataSO.KeyTileStates[_state].KeyColor;
		_sr.color = _color;
	}
}
