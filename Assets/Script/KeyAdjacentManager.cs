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
            Debug.Log($"①{_firstKey.KeyName}が格納されました。");
        }
        else if (_firstKey != null && _secondKey == null)
        {
            _secondKey = keyTile;
			Debug.Log($"②{_secondKey.KeyName}が格納されました。");

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
			Debug.Log("同じキーです！");
		}
        else if (distansX <= limit &&  distansY <= limit)
        {
            Debug.Log("隣接しています！");
            //目的キーのTileDataBaseを呼んで、引数に_firstのデータを渡す
            _secondKey.ChangeTileStates(_firstKey);
		}
        else
        {
            Debug.Log("隣接していません！");
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