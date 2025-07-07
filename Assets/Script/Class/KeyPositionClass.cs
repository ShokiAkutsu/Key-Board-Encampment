using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyPositionClass
{
	[SerializeField] private string key;
	[SerializeField] private Vector2 position;

	public string Key => key;
	public Vector2 Position => position;
}
