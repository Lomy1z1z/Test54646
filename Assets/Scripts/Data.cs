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
   public int levelData = GameMaster.instance.level;

<<<<<<< Updated upstream
   public float minDamagedata = PlayerM.instance.minDamage;
   public float maxDamagedata = PlayerM.instance.maxDamage;

   public float hpImageData =  PlayerM.instance.hpImage.fillAmount;
   public float hpBackGroundImageData =  PlayerM.instance.hpImageBackground.fillAmount;
   public float hpData = PlayerM.instance.hp;

   public float runSpeedData = PlayerM.instance.runspeed;

   public float attackRateData = PlayerM.instance.attackRate;

   public GameObject bulletTypeData;

   public bool tripleShootData;

   public bool ballSkillData;
   public bool shieldSkillData;
=======
    public GameObject bulletTypeData;
    
    public GameData GetGameData()
    {
        string json = JsonUtility.ToJson(gameData);
        GameData newData = JsonUtility.FromJson<GameData>(json);
        return newData;
    }
   
>>>>>>> Stashed changes

   
   

      
   
}
