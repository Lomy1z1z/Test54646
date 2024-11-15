using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeleeEnemy : Enemy
{

    [SerializeField] Rigidbody meleeEnemyBody;
    [SerializeField]  float meleeEnemySpeed;

    [SerializeField] float knockForce;
       public bool isPushed = false;

       private float knockTime = 0.15f;

    

     


    
    

 
    // Start is called before the first frame update
    void Start()
    {
        
            enemyHp = enemyHpImage.fillAmount;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        meleeEnemySpeed = 400;
        knockForce = 1000;

         enemyHpImage.fillAmount = enemyHp;

         transform.LookAt(GameMaster.instance.playerTransform);

         Vector3 direction = (GameMaster.instance.playerTransform.position - transform.position).normalized;

          if(isPushed == false){

           meleeEnemyBody.velocity = direction * meleeEnemySpeed * Time.fixedDeltaTime;
          }
          

         
         


         if(isPushed == true){
                 meleeEnemyBody.AddForce(transform.forward * -knockForce * Time.fixedDeltaTime,ForceMode.Impulse);
                 StartCoroutine(Reset());
             }

            
       

         

         
         


         
        
         
         
    }

       public void OnCollisionEnter(Collision other){
           if(other.gameObject.tag == "Bullet"){
              isPushed = true;
              TakeDamage(PlayerM.instance.enemyDamage/50);
           }

            if(other.gameObject.tag == "FireBullet"){
             isPushed = true;
             TakeDamage(PlayerM.instance.enemyDamage/50);
              burnChance = UnityEngine.Random.Range(0,101);
              if(burnChance > 70 && !isOnFire){
            isOnFire = true;
            fire.Play();
            StartCoroutine(FireDamage());
            StartCoroutine(StopFire());
              }
        }
           


       }
    
     IEnumerator Reset(){
         yield return new WaitForSeconds(knockTime);
         isPushed = false;
     }

    

    


   
}
