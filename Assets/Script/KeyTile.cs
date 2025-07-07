using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class KeyTile : MonoBehaviour
{
	//定義
	KeyStandardPositionSO _keyPositionSO;
	[SerializeField] Canvas _canvas;
	[SerializeField] Text _textAlphabet;
	SpriteRenderer _sr;
	//変数
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
		
        // 見た目更新(1, 2Pカラーにしたり、白に初期化したり)
        this.gameObject.name = _keyName;
		_textAlphabet.text = _keyName;

		Debug.Log($"{_keyName}は{_keyPosition}で設定");
	}

	private void WindowToCanvasRect()
	{
		//盤面に表示するアルファベットと位置を合わせる
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
	/// デバッグ用メソッド
	/// </summary>
	public void SetActiveRed()
	{
		_sr.color = Color.red;
	}
}
