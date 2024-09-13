using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManeger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]  GameObject enemy;
    [SerializeField] GameObject meleeEnemy;
    [SerializeField]  List<Transform> Spawns = new List<Transform>();
    [SerializeField] int enemyz;
    bool isWave2;
    bool isWave3;
    bool isWave4;
 
    void Start()
    {
          Invoke("Wave1",2);
        
    }

    // Update is called once per frame
    void Update()
    {

         int enemys = GameObject.FindGameObjectsWithTag("Enemy").Length;
         
        
        if(GameMaster.instance.killCount == 1 && isWave2 == false){
            isWave2 = true;
            Invoke("Wave2",2f);
        }
        if(GameMaster.instance.killCount == 3 && isWave3 == false){
             isWave3 = true;
            Invoke("Wave3",2f);
        }
        if(GameMaster.instance.killCount == 6  && isWave4 == false){
          isWave4 = true;
            Invoke("Wave4",2f);
        }
        
    }

     public void Wave1(){
         Instantiate(enemy,Spawns[0].position,transform.rotation);
         
     }
     public void Wave2(){
         Instantiate(enemy,Spawns[0].position,transform.rotation);
             Instantiate(enemy,Spawns[1].position,transform.rotation);

     }
     public void Wave3(){
         Instantiate(enemy,Spawns[0].position,transform.rotation);
             Instantiate(enemy,Spawns[1].position,transform.rotation);
             Instantiate(meleeEnemy,Spawns[2].position,transform.rotation);

    }
     public void Wave4(){
         Instantiate(enemy,Spawns[0].position,transform.rotation);
             Instantiate(enemy,Spawns[1].position,transform.rotation);
             Instantiate(meleeEnemy,Spawns[2].position,transform.rotation);
             Instantiate(meleeEnemy,Spawns[3].position,transform.rotation);

     }

     
    
}
