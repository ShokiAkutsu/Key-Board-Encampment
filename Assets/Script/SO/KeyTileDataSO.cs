using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyTileStatesData", menuName = "Keyboard/KeyTile States Data")]
public class KeyTileDataSO : ScriptableObject
{
	[SerializeField] List<KeyTileStatesList> _base;

	Dictionary<KeyTileState, KeyTileStatesClass> _keyTileStates;
	
	public Dictionary<KeyTileState, KeyTileStatesClass> KeyTileStates
	{
		get
		{
			if (_keyTileStates == null)
			{
				_keyTileStates = new Dictionary<KeyTileState, KeyTileStatesClass>();
				foreach (var entry in _base)
				{
					if (!_keyTileStates.ContainsKey(entry.KeyTileState))
					{
						_keyTileStates.Add(entry.KeyTileState, entry.ListBase);
					}
				}
			}
			return _keyTileStates;
		}
	}
}

[Serializable]
public class KeyTileStatesList
{
	[SerializeField] KeyTileState _keyTileState;
	[SerializeField] KeyTileStatesClass _listBase;

	public KeyTileState KeyTileState => _keyTileState;
	public KeyTileStatesClass ListBase => _listBase;
}