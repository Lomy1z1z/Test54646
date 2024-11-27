using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WaveManeger : MonoBehaviour
{
    // Start is called before the first frame update
    
    public List<Enemy> enemies = new List<Enemy>();
   
    public static WaveManeger instance; 
    public GameObject menuImg;
    public int currentWave = 0;
    public Wave wave;
    public int enemiesRemaning = 0;
    public TMP_Text enemytext;
    public TMP_Text waveNumText;
    public int waveNum = 1;

    public int waveWaitTime = 2;


    public bool finish;
    
    

    
     
    
   
    
    private void Awake(){
        

        if(instance != null && instance != this){
            Destroy(this);
        }else{
            DontDestroyOnLoad(this);
            instance = this;
        }
    }
 
    void Start()
    {

       

     StartCoroutine(WaveDelay());
     waveNumText.text = waveNum.ToString();

     
     

    }


    public void WaveSystem(){
        
        for(int i = 0; enemies.Count < wave.waves[currentWave].EnemiesToSpawn.Count &&  wave.waves[currentWave].IsCompleted == false; i ++ ){
            var enemySpawn = Instantiate(wave.waves[currentWave].EnemiesToSpawn[i],wave.waves[currentWave].SpawnPoints[i].position,transform.rotation);
            enemySpawn.OnDeath = OnEnemyDeath;
            enemies.Add(enemySpawn);
            enemiesRemaning = enemies.Count;
            enemytext.text = enemiesRemaning.ToString();
        }
        waveNumText.text = waveNum.ToString();
        waveNum++;
    }

    public void OnEnemyDeath(Enemy enemy){
        enemies.Remove(enemy);
        enemiesRemaning = enemies.Count;
        enemytext.text = enemiesRemaning.ToString();
        if (enemies.Count == 0){
            wave.waves[currentWave].IsCompleted = true;
            currentWave++;
            if(wave.waves.Count > currentWave){

              StartCoroutine(WaveDelay());
    
            }
            else{
                //  Time.timeScale = 0;
                // menuImg.SetActive(true);
                // finish = true;
                SceneManager.LoadScene(2);
                GameMaster.instance.DestroyThyself();
                
                   
            }
        }

    }

    public IEnumerator WaveDelay(){
         yield return new WaitForSeconds(waveWaitTime);
         WaveSystem();
         
     }

     


   


    


   }
   


    

   



    

    
      

    



   

     


     
    

