using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "new Level")]
public class LevelSc : ScriptableObject
{
	public List<GameObject> toys = new List<GameObject>();
}
