using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAdjacentManager : MonoBehaviour
{
    KeyTileDataBase _firstKey;
    KeyTileDataBase _secondKey;

    public void HandleKeyInput(KeyTileDataBase keyTile)
    {
        if (_firstKey == null && IsPlayerState(keyTile.State))
        {
            _firstKey = keyTile;
            Debug.Log($"�@{_firstKey.KeyName}���i�[����܂����B");
        }
        else if (_firstKey != null && _secondKey == null)
        {
            _secondKey = keyTile;
			Debug.Log($"�A{_secondKey.KeyName}���i�[����܂����B");

			IsAdjacent();
			_firstKey = null;
			_secondKey = null;
		}
    }

    private void IsAdjacent()
    {
        float limit = 1.0f;

        float distansX = Mathf.Abs(_firstKey.KeyPosition.x - _secondKey.KeyPosition.x);
        float distansY = Mathf.Abs(_firstKey.KeyPosition.y - _secondKey.KeyPosition.y);

        if (_firstKey == _secondKey)
        {
			Debug.Log("�����L�[�ł��I");
		}
        else if (distansX <= limit &&  distansY <= limit)
        {
            Debug.Log("�אڂ��Ă��܂��I");
            //�ړI�L�[��TileDataBase���Ă�ŁA������_first�̃f�[�^��n��
            _secondKey.ChangeTileStates(_firstKey);
		}
        else
        {
            Debug.Log("�אڂ��Ă��܂���I");
        }
	}

	public static bool IsPlayerState(KeyTileState state)
	{
		return state == KeyTileState.Player_Red || state == KeyTileState.Player_Blue;
	}

	public static bool IsTerrainState(KeyTileState state)
	{
		return state == KeyTileState.River || state == KeyTileState.Rock;
	}
}