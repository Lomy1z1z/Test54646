using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "SaveData", menuName = "GameData")]
public class Data : ScriptableObject
{
   [SerializeField] private GameData gameData;

    public GameObject bulletTypeData;

    public GameData GetGameData()
    {
        string json = JsonUtility.ToJson(gameData);
        GameData newData = JsonUtility.FromJson<GameData>(json);
        return newData;
    }
   

   
   

      
   
}
[Serializable]
public class GameData{
    public int levelData;

   public float minDamageData;
   public float maxDamageData;

   public float hpImageData;
   public float hpBackGroundImageData;
   public float hpData;

   public float runSpeedData;

   public float attackRateData;

   public bool tripleShootData;

   public bool ballSkillData;
   public bool shieldSkillData;
   }
