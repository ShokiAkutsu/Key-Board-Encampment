using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
	[Header("�L�[�z����SO")]
	[SerializeField] KeyStandardPositionSO _layoutData;
	[Header("�L�[�v���n�u�̊i�[")]
	[SerializeField] KeyTileDataBase _keyTilePrefab;
	[Header("�L�[���m�̊Ԋu")]
	[SerializeField] float _keyDistance = 1.2f;
	[Header("�L�[Prefab�̕ێ�Obj")]
	[SerializeField] Transform _parent;

	Dictionary<KeyCode, KeyTileDataBase> _tiles;	//�L�[�{�[�h�z��̏��List
	KeyAdjacentManager _AdjacentManager;

	private void Start()
	{
		List<KeyValuePair<string, Vector2>> _keyPosition = _layoutData.GetAllKeyValuePairs();
		_tiles = new Dictionary<KeyCode, KeyTileDataBase>();

		foreach (var keyData in _keyPosition)
		{
			Vector2 worldPos = GridToWorldPosition(keyData.Value);
			KeyTileDataBase tile = Instantiate(_keyTilePrefab, worldPos, Quaternion.identity, _parent);
			tile.Init(keyData);
			//�Ή��L�[�R�[�h���i�[����
			KeyCode keyCode;
			System.Enum.TryParse(keyData.Key, true, out keyCode);

			_tiles[keyCode] = tile;
		}

		_keyPosition.Clear();

		_AdjacentManager = GameObject.Find("Manager").GetComponent<KeyAdjacentManager>();
	}

	private void Update()
	{
		foreach (KeyCode key in _tiles.Keys)
		{
			if (Input.GetKeyDown(key))
			{
				// �Ή�����^�C�����擾
				KeyTileDataBase tile = _tiles[key];
				// �^�C���ɖ���(�f�o�b�O�p�֐�)
				//tile.SetActiveRed();
				//�אڔ���A�����ꂽ�L�[�̊i�[
				_AdjacentManager.HandleKeyInput(tile);
			}
		}
	}

	/*
	/// <summary>
	/// �L�[���W(��ʏ�)�̍��W���擾
	/// </summary>
	public Vector2Int GetKeyPosition(string key)
	{
		if (_tiles.TryGetValue(key, out var pos))
		{
			return pos;
		}
			
		return new Vector2Int(-1, -1); // �ʒu���Ȃ��ꍇ
	}
	*/

	/// <summary>
	/// �O���b�h���W�����[���h���W�ɕϊ�
	/// </summary>
	private Vector2 GridToWorldPosition(Vector2 grid)
	{
		//Y�����̔z�u���t�ɐݒ肷��
		float reversal = -1.0f;
		Vector2 parentPos = _parent.transform.position;
		//Key�z���񂩂�Ԋu���J���č��W���w��
		Vector2 pos = new Vector2(grid.x * _keyDistance, grid.y * _keyDistance * reversal);

		return pos + parentPos;
	}
}
