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
        
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        expImage.fillAmount = exp;

        levelText.text = level.ToString();

        if(exp >= 1){
            LevelUp();
            exp = 0;
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



     }

     public void RestartLevel(){
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




     


     

     
}
