using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Enemy : MonoBehaviour
{
    public float dis;
    PlayerM playerScript;
    public Transform player;
    public Image enemyHpImage;
    public float enemyHp;
    GameMaster gm;
    public GameObject enemyBullet;
    public Transform enemyGun;
     [SerializeField] private float nextAttackTime = 0f;
     [SerializeField] private float attackRate = 1f;

     public float enemyDamege = 0.2f;

     

     public Action<Enemy> OnDeath;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemyHpImage.fillAmount;
       
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
         
        enemyHpImage.fillAmount = enemyHp;
        //  dis  = Vector3.Distance(transform.position,player.position);
         
         transform.LookAt(GameMaster.instance.playerTransform.position);
         
         if(Time.time>=nextAttackTime){
         enemyShooting();
         nextAttackTime=Time.time+1/attackRate;
         }

         

        
         
    }


    public void TakeDamage(float damage){
        enemyHp -= damage;

        if(enemyHp <= 0)
        {
            Destroy(gameObject);
            GameMaster.instance.exp += 1f;
         }

        
    }

   public void OnDestroy(){
    OnDeath?.Invoke(this);
 
   
   }
    

    public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == Bullet){
            TakeDamage(PlayerM.instance.enemyDamege);
        }
    }


    private const string Bullet = "Bullet";


    public void enemyShooting(){
        Instantiate(enemyBullet,enemyGun.position,transform.rotation);

    }

    
   

        


        

        

}
