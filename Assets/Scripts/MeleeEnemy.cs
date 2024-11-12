using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeleeEnemy : Enemy
{

    [SerializeField] Rigidbody meleeEnemyBody;
<<<<<<< HEAD
    [SerializeField]  float MeleeEnemySpeed;
=======
    [SerializeField]  float meleeEnemySpeed;
>>>>>>> waves

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

<<<<<<< HEAD
        MeleeEnemySpeed = 400;
=======
        meleeEnemySpeed = 400;
>>>>>>> waves
        knockForce = 1000;

         enemyHpImage.fillAmount = enemyHp;

         transform.LookAt(GameMaster.instance.playerTransform);

         Vector3 direction = (GameMaster.instance.playerTransform.position - transform.position).normalized;

          if(isPushed == false){

<<<<<<< HEAD
           meleeEnemyBody.velocity = direction * MeleeEnemySpeed * Time.fixedDeltaTime;
=======
           meleeEnemyBody.velocity = direction * meleeEnemySpeed * Time.fixedDeltaTime;
>>>>>>> waves
          }
          

         
         


         if(isPushed == true){
                 meleeEnemyBody.AddForce(transform.forward * -knockForce * Time.fixedDeltaTime,ForceMode.Impulse);
                 StartCoroutine(Reset());
             }

            
       

         

         
         


         
        
         
         
    }

       public void OnCollisionEnter(Collision other){
           if(other.gameObject.tag == "Bullet"){
              isPushed = true;
<<<<<<< HEAD
              TakeDamage(PlayerM.instance.enemyDamege/50);
=======
              TakeDamage(PlayerM.instance.enemyDamage/50);
>>>>>>> waves
           }

            if(other.gameObject.tag == "FireBullet"){
             isPushed = true;
<<<<<<< HEAD
             TakeDamage(PlayerM.instance.enemyDamege/50);
=======
             TakeDamage(PlayerM.instance.enemyDamage/50);
>>>>>>> waves
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
