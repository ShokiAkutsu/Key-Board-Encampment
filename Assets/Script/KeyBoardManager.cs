using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
	[Header("キー配列情報SO")]
	[SerializeField] KeyStandardPositionSO _layoutData;
	[Header("キープレハブの格納")]
	[SerializeField] KeyTile _keyTilePrefab;
	[Header("キー同士の間隔")]
	[SerializeField] float _keyDistance = 1.2f;
	[Header("キーPrefabの保持Obj")]
	[SerializeField] Transform _parent;

	Dictionary<KeyCode, KeyTile> _tiles;	//キーボード配列の情報List

	private void Start()
	{
		List<KeyValuePair<string, Vector2>> _keyPosition = _layoutData.GetAllKeyValuePairs();
		_tiles = new Dictionary<KeyCode, KeyTile>();

		foreach (var keyData in _keyPosition)
		{
			Vector2 worldPos = GridToWorldPosition(keyData.Value);
			KeyTile tile = Instantiate(_keyTilePrefab, worldPos, Quaternion.identity, _parent);
			tile.Init(keyData);
			//対応キーコードを格納する
			KeyCode keyCode;
			System.Enum.TryParse(keyData.Key, true, out keyCode);

			_tiles[keyCode] = tile;
		}

		_keyPosition.Clear();
	}

	private void Update()
	{
		foreach (KeyCode key in _tiles.Keys)
		{
			if (Input.GetKeyDown(key))
			{
				// 対応するタイルを取得
				KeyTile tile = _tiles[key];
				// タイルに命令(デバッグ用関数)
				tile.SetActiveRed();
			}
		}
	}

	/*
	/// <summary>
	/// キー座標(画面上)の座標を取得
	/// </summary>
	public Vector2Int GetKeyPosition(string key)
	{
		if (_tiles.TryGetValue(key, out var pos))
		{
			return pos;
		}
			
		return new Vector2Int(-1, -1); // 位置がない場合
	}
	*/

	/// <summary>
	/// グリッド座標をワールド座標に変換
	/// </summary>
	private Vector2 GridToWorldPosition(Vector2 grid)
	{
		//Y方向の配置を逆に設定する
		float reversal = -1.0f;
		Vector2 parentPos = _parent.transform.position;
		//Key配列情報から間隔を開けて座標を指定
		Vector2 pos = new Vector2(grid.x * _keyDistance, grid.y * _keyDistance * reversal);

		return pos + parentPos;
	}
}
