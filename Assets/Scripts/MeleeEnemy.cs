using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeleeEnemy : Enemy
{

    [SerializeField] Rigidbody meleeEnemyBody;
    [SerializeField]  float MeleeEnemySpeed;
    public float knock = 1;
    

 
    // Start is called before the first frame update
    void Start()
    {
        
            enemyHp = enemyHpImage.fillAmount;
       
    }

    // Update is called once per frame
    void Update()
    {

         enemyHpImage.fillAmount = enemyHp;


         
       

         

         
         


         Debug.Log(GameMaster.instance.isPooshed);
        
         
         
    }

    // public void OnCollisionEnter(Collision other){
    //     if(other.gameObject.tag == "Bullet"){
    
    //     }
    // }
    
     IEnumerator Reset(){
         yield return new WaitForSeconds(0.5f);
         GameMaster.instance.isPooshed = false;
     }

    

    


   
}
