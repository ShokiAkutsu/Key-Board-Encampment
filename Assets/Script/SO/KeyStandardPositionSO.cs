using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

[CreateAssetMenu(fileName = "KeyStandardPositionData", menuName = "Keyboard/Key StandardPosition Data")]
public class KeyStandardPositionSO : ScriptableObject
{
	[Header("è„íi")]
	[SerializeField] List<KeyPositionClass> upperPositions;
	[Header("íÜíi")]
	[SerializeField] List<KeyPositionClass> middlePositions;
	[Header("â∫íi")]
	[SerializeField] List<KeyPositionClass> lowerPositions;

	public Dictionary<string, Vector2> ToDictionary()
	{
		var dict = new Dictionary<string, Vector2>();
		foreach (var kp in upperPositions) dict[kp.Key] = kp.Position;
		foreach (var kp in middlePositions) dict[kp.Key] = kp.Position;
		foreach (var kp in lowerPositions) dict[kp.Key] = kp.Position;
		return dict;
	}

	public List<KeyValuePair<string, Vector2>> GetAllKeyValuePairs()
	{
		List<KeyValuePair<string, Vector2>> list = new List<KeyValuePair<string, Vector2>>();

		list.AddRange(upperPositions.Select(d => new KeyValuePair<string, Vector2>(d.Key, d.Position)).ToList());
		list.AddRange(middlePositions.Select(d => new KeyValuePair<string, Vector2>(d.Key, d.Position)).ToList());
		list.AddRange(lowerPositions.Select(d => new KeyValuePair<string, Vector2>(d.Key, d.Position)).ToList());

		return list;
	}
}
