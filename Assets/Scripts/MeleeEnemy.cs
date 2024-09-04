using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeleeEnemy : Enemy
{

    [SerializeField] Rigidbody meleeEnemyBody;
    [SerializeField]  float MeleeEnemySpeed;
    

 
    // Start is called before the first frame update
    void Start()
    {
        
            
       
    }

    // Update is called once per frame
    void Update()
    {


         if(GameMaster.instance.isPooshed == false){

         transform.position = Vector3.MoveTowards(transform.position,GameMaster.instance.playerTransform.position,MeleeEnemySpeed);
         }


         Debug.Log(GameMaster.instance.isPooshed);
        
         
         
    }


   
}
