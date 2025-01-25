using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{
    public Image expImage;
    public static GameMaster instance; 
    public float exp;
    public TMP_Text levelText;
    public int level = 1;
    public Transform playerTransform;
    public GameObject skillPick;

    public float skillPoints;

    
    public Camera cam;

    public TMP_Text textSP;


    public float damageToPrint;

     public TMP_Text damageText;

     public float sparkleExpAmount = 0.35f;

     public Transform bombTransform;

     public Data data;

     public GameObject ballSkill;

    public GameObject shieldSkill;

<<<<<<< Updated upstream
=======
    public const float reduceExpAmountPerLevel = 0.05f;
    public GameData inGameData;

    public GameObject bulletType;

    public Transform playerStartPos;


     public GameObject fireBulletPick;
    public GameObject TripleShotPick;

    public GameObject ballSkillPick;
    public GameObject shieldSkillPick;

    public GameObject lobbyScreen;

   



>>>>>>> Stashed changes
     

     


     

    

    



   

    
    

    
    

    private void Awake(){
        

        if(instance != null && instance != this){
            Destroy(this);
        }else{
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!lobbyScreen.activeSelf){
            Time.timeScale = 1;
        }else{
            Time.timeScale = 0;
        }


<<<<<<< Updated upstream
        Time.timeScale = 1;
=======


        ResetCharacterStats();
        
        level = inGameData.levelData;
>>>>>>> Stashed changes

        level = data.levelData;
       
    }

    // Update is called once per frame
    void Update()
    {
        expImage.fillAmount = exp;

        levelText.text = level.ToString();
        textSP.text = skillPoints.ToString();

        if(exp >= 1){
            LevelUp();
             data.levelData = level; 
        }

       

        

        

       

         

    }

     


    public void DestroyThyself()
{
    
   Destroy(gameObject);
   instance = null;    // because destroy doesn't happen until end of frame
}

    

    


     public void LevelUp(){
         level += 1;
         skillPick.SetActive(true);
          Time.timeScale = 0;
          skillPoints +=1;
          exp = 0;
          sparkleExpAmount -= 0.05f;
          

     }

<<<<<<< Updated upstream
     public void RestartLevel(){
         data.levelData = 1;

    data.minDamagedata = 1;
    data.maxDamagedata = 10;
=======
    public void RestartLevel(int time_Scale){
    WaveManeger.instance.reLevel = true;
    StartCoroutine(WaveManeger.instance.ResetGame());
    level = inGameData.levelData;
    PlayerM.instance.transform.position = playerStartPos.position;
    WaveManeger.instance.StartCoroutine(WaveManeger.instance.WaveDelay());
    WaveManeger.instance.currentWave = 0;
    WaveManeger.instance.waveNum = 1;
    WaveManeger.instance.waveNumText.text =   WaveManeger.instance.waveNum.ToString();
     WaveManeger.instance.menuImg.SetActive(false);
     Time.timeScale = time_Scale;
     ResetCharacterStats();

     WaveManeger.instance.DestroyEnemies();

    
    string[] tagsToDestroy = new string[] { "enemyBall","Bullet","FireBullet","exp" };
>>>>>>> Stashed changes

    data.hpImageData =  0.3f;
    data.hpBackGroundImageData =  0.3f;
    data.hpData = 30f;

    data.runSpeedData = 25f;

   data.attackRateData = 0.1f;
   data.shieldSkillData = false;
   data.ballSkillData = false;
   data.tripleShootData = false;
   data.bulletTypeData = PlayerM.instance.bullet;
        SceneManager.LoadScene(1);
         DestroyThyself();
     }

     public void MenuBotton(){
        Time.timeScale = 0;
        WaveManeger.instance.menuImg.SetActive(true);
     }
     public void ReturnToLobby(){
<<<<<<< Updated upstream
         data.levelData = 1;

    data.minDamagedata = 1;
    data.maxDamagedata = 10;

    data.hpImageData =  0.3f;
    data.hpBackGroundImageData =  0.3f;
    data.hpData = 30f;

    data.runSpeedData = 25f;

   data.attackRateData = 0.1f;
   data.shieldSkillData = false;
   data.ballSkillData = false;
   data.tripleShootData = false;
   data.bulletTypeData = PlayerM.instance.bullet;
        SceneManager.LoadScene(0);
        DestroyThyself();
=======
        Time.timeScale = 0;
        lobbyScreen.SetActive(true);
        RestartLevel(0);
        
        
       
        
>>>>>>> Stashed changes
        
        
     }
     public void ResumeGame(){
        if(WaveManeger.instance.finish == false){
         Time.timeScale = 1;
         WaveManeger.instance.menuImg.SetActive(false);
         }
        
     }
     
     public void ExitTab(GameObject window){

        window.SetActive(false);

     }

<<<<<<< Updated upstream
=======
     public void PlayButton(){
        lobbyScreen.SetActive(false);
         Time.timeScale = 1;
     }

      public void ResetCharacterStats(){
        inGameData = data.GetGameData();
        bulletType = data.bulletTypeData;
        ballSkill.SetActive(false);
        shieldSkill.SetActive(false);
          fireBulletPick.SetActive(false);
          TripleShotPick.SetActive(false);
           ballSkillPick.SetActive(false);
          shieldSkillPick.SetActive(false);
          PlayerM.instance.minDamage = inGameData.minDamageData;
         PlayerM.instance.maxDamage = inGameData.maxDamageData;
           PlayerM.instance.runspeed = inGameData.runSpeedData;
            PlayerM.instance.hp = inGameData.hpData;
            PlayerM.instance.hpImage.fillAmount = inGameData.hpImageData;
            PlayerM.instance.hpImageBackground.fillAmount = inGameData.hpBackGroundImageData;
             PlayerM.instance.attackRate = inGameData.attackRateData;
            

    }

>>>>>>> Stashed changes

    

      


    



     


     

     
}
