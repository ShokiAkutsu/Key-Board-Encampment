using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class KeyTile : MonoBehaviour
{
	//��`
	KeyStandardPositionSO _keyPositionSO;
	[SerializeField] Canvas _canvas;
	[SerializeField] Text _textAlphabet;
	SpriteRenderer _sr;
	//�ϐ�
	string _keyName;
	Vector2 _keyPosition;
	public string KeyName => _keyName;
	public Vector2 KeyPosition => _keyPosition;

	private void Start()
	{
		_sr = GetComponent<SpriteRenderer>();
	}

	public void Init(KeyValuePair<string, Vector2> data)
	{
		_keyName = data.Key;
		_keyPosition = data.Value;

		WindowToCanvasRect();
		
        // �����ڍX�V(1, 2P�J���[�ɂ�����A���ɏ�����������)
        this.gameObject.name = _keyName;
		_textAlphabet.text = _keyName;

		Debug.Log($"{_keyName}��{_keyPosition}�Őݒ�");
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
	/// �f�o�b�O�p���\�b�h
	/// </summary>
	public void SetActiveRed()
	{
		_sr.color = Color.red;
	}
}
