using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "startData", menuName = "StartLoader")]

public class StartData : ScriptableObject
{
   public Image expImageData;
   public float expData;
       public TMP_Text levelTextData;
    public int levelData;
    public GameObject skillPickData;

    public float skillPointsData;

    
    public Camera camData;

    public TMP_Text textSPData;

    public float damageToPrintData;

     public TMP_Text damageTextData;

     public float sparkleExpAmountData;


     public GameObject ballSkillData;

    public GameObject shieldSkillData;

    public  float reduceExpAmountPerLevelData;

    public GameObject bulletTypeData;
}
