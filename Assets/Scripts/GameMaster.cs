using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameMaster : MonoBehaviour
{
    public Image expImage;
    public static GameMaster instance; 
    public float exp;
    public TMP_Text levelText;
    public int level = 1;
    public Transform playerTransform;
    public bool isPooshed = false;
     public float killCount;
    

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
        level = 1;
        killCount = 0;
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

    


     public void LevelUp(){
         level += 1;


     }

     
}
