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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(skills.Length);
    }

public void PlayRollete(){
    if(!isRolled){
        int randomNuber = Random.Range(0,skills.Length);
        isRolled = true;
    
           switch (randomNuber) 
{
  case 0:
    CurrentSkill = skills[0];
     PlayerM.instance.enemyDamege += 0.21f;

    break;
  case 1:
    CurrentSkill = skills[1];
     PlayerM.instance.hpImage.fillAmount += 0.1f;
     PlayerM.instance.hpImageBackground.fillAmount += 0.1f;
     PlayerM.instance.hp += 10;
     
    break;
  case 2:
    CurrentSkill = skills[2];
    PlayerM.instance.runspeed +=3;
    break;
  case 3:
   CurrentSkill = skills[3];
   PlayerM.instance.attackRate +=1;
    break;

}
        


    

    

    CurrentSkill.SetActive(true);

 
    }
    
    

    
         
}

public void Continue(){
    if(isRolled){
        CurrentSkill.SetActive(false);
        CurrentSkill = null;
        isRolled = false;
         Time.timeScale = 1;
         gameObject.SetActive(false);
    }
}


public void FrieBulletSkill(){
    if(GameMaster.instance.skillPoints > 0){
    fireBulletPick.SetActive(true);
    PlayerM.instance.bullet = PlayerM.instance.fireBullet;
    GameMaster.instance.skillPoints -=1;

    }

}
public void TripleShotActive(){
    if(GameMaster.instance.skillPoints > 0){
    TripleShotPick.SetActive(true);
    PlayerM.instance.tripleShot = true;
    GameMaster.instance.skillPoints -=1;

    }

}
}
