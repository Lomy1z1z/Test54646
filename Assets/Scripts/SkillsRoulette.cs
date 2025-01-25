using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRollete : MonoBehaviour
{
    public GameObject [] skills;
    public GameObject CurrentSkill;
    public bool isRolled;

    public GameObject fireBulletPick;
    public GameObject TripleShotPick;

    public GameObject ballSkillPick;
    public GameObject shieldSkillPick;

    // public GameObject ballSkill;

    // public GameObject shildSkill;

    public GameObject rollAlert;

    public GameObject continueAlert;

    public bool isFireBall;
    public bool isTripleShot;
    public bool isBallSkill;

    public bool isShieldSkill;
    public float shootAnim = 1.5f;
     

    

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

public void PlayRollete(){
    if(!isRolled){
        int randomNuber = Random.Range(0,skills.Length);
        isRolled = true;
    
           switch (randomNuber) 
{
  case 0:
    CurrentSkill = skills[0];
     PlayerM.instance.minDamage += 3;
     PlayerM.instance.maxDamage += 3;
     GameMaster.instance.damageToPrint = PlayerM.instance.enemyDamage * 10;
     GameMaster.instance.damageText.text = GameMaster.instance.damageToPrint.ToString();
     GameMaster.instance.data.minDamagedata = PlayerM.instance.minDamage;
     GameMaster.instance.data.maxDamagedata = PlayerM.instance.maxDamage;
    break;
  case 1:
    CurrentSkill = skills[1];
     PlayerM.instance.hpImage.fillAmount += 0.1f;
     PlayerM.instance.hpImageBackground.fillAmount += 0.1f;
     PlayerM.instance.hp += 10;
     GameMaster.instance.data.hpImageData =  PlayerM.instance.hpImage.fillAmount;
     GameMaster.instance.data.hpBackGroundImageData =  PlayerM.instance.hpImageBackground.fillAmount;
     GameMaster.instance.data.hpData =  PlayerM.instance.hp;
    break;
  case 2:
    CurrentSkill = skills[2];
    PlayerM.instance.runspeed +=3;
     GameMaster.instance.data.runSpeedData =  PlayerM.instance.runspeed;
    break;
  case 3:
   CurrentSkill = skills[3];
   GameMaster.instance.data.attackRateData = PlayerM.instance.attackRate;
   PlayerM.instance.attackRate +=1;
   
   shootAnim += 0.5f;
   PlayerM.instance.animator.SetFloat("shootSpeed",shootAnim);
    break;

}
        


    

    

    CurrentSkill.SetActive(true);

 
    }else{
        rollAlert.SetActive(true);

    }
    
    

    
         
}

public void Continue(){
    if(isRolled){
        CurrentSkill.SetActive(false);
        CurrentSkill = null;
        isRolled = false;
         Time.timeScale = 1;
         gameObject.SetActive(false);
    }else{

        continueAlert.SetActive(true);

    }
}

// Choiceble Skills:
public void FrieBulletSkill(){
    if(GameMaster.instance.skillPoints > 0 && isFireBall == false){
    fireBulletPick.SetActive(true);
    PlayerM.instance.bullet = PlayerM.instance.fireBullet;
    GameMaster.instance.skillPoints -=1;
    isFireBall = true;
    GameMaster.instance.data.bulletTypeData = PlayerM.instance.fireBullet;
    }

}
public void TripleShotActive(){
    if(GameMaster.instance.skillPoints > 0 && isTripleShot == false){
    TripleShotPick.SetActive(true);
    PlayerM.instance.tripleShot = true;
    GameMaster.instance.skillPoints -=1;
    isTripleShot = true;
    GameMaster.instance.data.tripleShootData = PlayerM.instance.tripleShot;
    }

}
public void BallSkillActive(){
    if(GameMaster.instance.skillPoints > 0 && GameMaster.instance.inGameData.ballSkillData == false){
    ballSkillPick.SetActive(true);
    GameMaster.instance.ballSkill.SetActive(true);
    GameMaster.instance.skillPoints -=1;
<<<<<<< Updated upstream
    isBallSkill = true;
    GameMaster.instance.data.ballSkillData = true;
=======
    //isBallSkill = true;
    GameMaster.instance.inGameData.ballSkillData = true;
>>>>>>> Stashed changes
    }
    

}
public void ShildSkillActive(){
    if(GameMaster.instance.skillPoints > 0 && GameMaster.instance.inGameData.shieldSkillData == false){
    shieldSkillPick.SetActive(true);
    GameMaster.instance.shieldSkill.SetActive(true);
    GameMaster.instance.skillPoints -=1;
<<<<<<< Updated upstream
    isShieldSkill = true;
    GameMaster.instance.data.shieldSkillData = true;
=======
    //isShieldSkill = true;
    GameMaster.instance.inGameData.shieldSkillData = true;
>>>>>>> Stashed changes
    }

    

}


}
