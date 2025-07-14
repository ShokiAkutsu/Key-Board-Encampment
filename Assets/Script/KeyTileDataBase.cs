using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class KeyTileDataBase : MonoBehaviour
{
	//定義
	KeyStandardPositionSO _keyPositionSO;
	[SerializeField] KeyTileDataSO _keyTileDataSO;
	[SerializeField] Canvas _canvas;
	[SerializeField] Text _textAlphabet;
	SpriteRenderer _sr;
	Color _color;
	//変数
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
		
        // 見た目更新(1, 2Pカラーにしたり、白に初期化したり)
        this.gameObject.name = _keyName;
		_textAlphabet.text = _keyName;


		//デバッグ用　あとで別マネージャーで管理するようにする
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
	/// KeyTileのステータスのアップデート
	/// </summary>
	public void ChangeTileStates(KeyTileDataBase data)
	{
		_state = data._state;
		_color = _keyTileDataSO.KeyTileStates[_state].KeyColor;
		_sr.color = _color;
	}
}
