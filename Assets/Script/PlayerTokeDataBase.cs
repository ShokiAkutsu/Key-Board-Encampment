using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTokeDataBase : MonoBehaviour
{
    InputState _inputState;
    //どこのキーにいるのか
    //場所の格納はKeyTileDataBaseかな？
    //駒ごとにID割り振って、他が選択中の時選択できないようにするとか
    //駒の場所から隣接していたら動けるようにしたい
    //そして、駒を動かしたい
    //駒はWorld座標系に直さないとかな

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum InputState
{
	Idle,
	Selecting,
	Confirming,
	Resolving
}