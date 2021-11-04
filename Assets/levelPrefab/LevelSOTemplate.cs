using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelHolderAsset", menuName = "Create Level Holder Asset", order = 1)]
public class LevelSOTemplate : ScriptableObject
{
    public List<GameObject> mapPrefabs;

} // class