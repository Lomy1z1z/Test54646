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

   public float minDamagedata = PlayerM.instance.minDamage;
   public float maxDamagedata = PlayerM.instance.maxDamage;

   public float hpImageDeta =  PlayerM.instance.hpImage.fillAmount;
   public float hpBackGroundImageDeta =  PlayerM.instance.hpImageBackground.fillAmount;
   public float hpData = PlayerM.instance.hp;

   public float runSpeedData = PlayerM.instance.runspeed;

   public float attackRateData = PlayerM.instance.attackRate;

   public GameObject bulletTypeData;

   public bool tripleShootData;

   public bool ballSkillData;
   public bool shildSkillData;

   
   

      
   
}
