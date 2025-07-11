using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyTileStatesClass
{
	[SerializeField] Color _color;
	public Color KeyColor => _color;
}

[Serializable]
public enum KeyTileState
{
	//êwâc
	None,
	Player_Red,
	Player_Blue,
	//ínå`
	River,
	Rock,
}