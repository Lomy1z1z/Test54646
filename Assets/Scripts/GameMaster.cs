using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameMaster : MonoBehaviour
{
    public Image expImage;
    public float exp;
    public TMP_Text levelText;
    public int level = 1;

    // Start is called before the first frame update
    void Start()
    {
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

    


     public void LevelUp(){
         level += 1;


     }
}
