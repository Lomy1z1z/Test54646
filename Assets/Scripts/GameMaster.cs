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

    public const float reduceExpAmountPerLevel = 0.05f;

     

     


     

    

    



   

    
    

    
    

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


        Time.timeScale = 1;

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
          sparkleExpAmount -= reduceExpAmountPerLevel;
          

     }

     public void RestartLevel(){
        ResetCharacterStats();
        // WaveManeger.instance.StartCoroutine(WaveManeger.instance.WaveDelay());
        // WaveManeger.instance.currentWave = 0;
        //     GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        // foreach(GameObject go in gos)
        //  Destroy(go);
        //  for(int i = 0; i < WaveManeger.instance.wave.waves.Count; i ++){
        //      WaveManeger.instance.wave.waves[i].IsCompleted = false;
        //  }
         
      
      
        

        SceneManager.LoadScene(1);
         DestroyThyself();
     }

     public void MenuBotton(){
        Time.timeScale = 0;
        WaveManeger.instance.menuImg.SetActive(true);
     }
     public void ReturnToLobby(){
        
        SceneManager.LoadScene(0);
        DestroyThyself();
        
        
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

     public void ResetCharacterStats(){
         data.levelData = 1;

    data.minDamageData = 1;
    data.maxDamageData = 10;

    data.hpImageData =  0.3f;
    data.hpBackGroundImageData =  0.3f;
    data.hpData = 30f;

    data.runSpeedData = 25f;

   data.attackRateData = 0.1f;
   data.shieldSkillData = false;
   data.ballSkillData = false;
   data.tripleShootData = false;
   data.bulletTypeData = PlayerM.instance.bullet;
     }


    

      


    



     


     

     
}
