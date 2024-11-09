using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSparkle : MonoBehaviour
{

    public Rigidbody sparkleBody;

    public float sparkleSpeed = 1000;
    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.LookAt(GameMaster.instance.playerTransform);
         Vector3 direction = (GameMaster.instance.playerTransform.position - transform.position).normalized;


         if(WaveManeger.instance.enemiesRemaning == 0){

         sparkleBody.velocity = direction * sparkleSpeed * Time.fixedDeltaTime;

         }

         
         
    }




   


    
}
