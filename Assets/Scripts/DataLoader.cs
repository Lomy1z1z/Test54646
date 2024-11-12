using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DataLoader : MonoBehaviour


{

     public Data data; 

     private void Start(){
        
     }
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
  
        
        GameMaster.instance.level = data.levelData;
        PlayerM.instance.minDamage = data.minDamagedata;
        PlayerM.instance.maxDamage = data.maxDamagedata;
<<<<<<< HEAD
        PlayerM.instance.hpImage.fillAmount = data.hpImageDeta;
        PlayerM.instance.hpImageBackground.fillAmount = data.hpBackGroundImageDeta;
=======
        PlayerM.instance.hpImage.fillAmount = data.hpImageData;
        PlayerM.instance.hpImageBackground.fillAmount = data.hpBackGroundImageData;
>>>>>>> waves
        PlayerM.instance.hp = data.hpData;
        PlayerM.instance.runspeed = data.runSpeedData;
        PlayerM.instance.attackRate = data.attackRateData;
        PlayerM.instance.bullet = data.bulletTypeData;
        PlayerM.instance.tripleShot = data.tripleShootData;
<<<<<<< HEAD
        GameMaster.instance.shildSkill.SetActive(data.shildSkillData);
=======
        GameMaster.instance.shieldSkill.SetActive(data.shieldSkillData);
>>>>>>> waves
        GameMaster.instance.ballSkill.SetActive(data.ballSkillData);
    }

    


   
    


     

    
}
