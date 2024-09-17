using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManeger : MonoBehaviour
{
    // Start is called before the first frame update

    
    public List<GameObject> enemies = new List<GameObject>();
   
    public static WaveManeger instance; 
    public List<Wave> wave = new List<Wave>();
    int currentWave = 0;
    
   
    
    


    
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
        
     

    }

    // Update is called once per frame
    void Update()
    {

        if(enemies.Count == 0){
            Level1();
            currentWave ++;
        }
    }


     public void Level1(){
       
            for(int i = 0; i < wave[currentWave].EnemiesToSpawn.Count; i++){
             enemies.Add(Instantiate(wave[currentWave].EnemiesToSpawn[i],wave[currentWave].SpawnPoints[i].position,transform.rotation));
            }
            
            
            
        
     }


     
    
}
