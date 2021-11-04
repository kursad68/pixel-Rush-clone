using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapCreator : MonoBehaviour
{
    public LevelSOTemplate mapObjects;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            int tmpLevelCount = PlayerPrefs.GetInt("CurrentLevel");
            
            if (tmpLevelCount < mapObjects.mapPrefabs.Count)
            {
                Instantiate(mapObjects.mapPrefabs[PlayerPrefs.GetInt("CurrentLevel")]);
            }
            else
            {
                Instantiate(mapObjects.mapPrefabs[0]);
                PlayerPrefs.SetInt("CurrentLevel", 0);
            }
        }
        else
        {
            PlayerPrefs.SetInt("CurrentLevel", 0);
            Instantiate(mapObjects.mapPrefabs[0]);
        }

    } // Awake()

} // class
