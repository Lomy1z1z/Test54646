using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float dis;
    public Transform player;
    public Image enemyHpImage;
    public float enemyHp;
    public GameObject enemyBullet;
    public Transform enemyGun;
     [SerializeField] public float nextAttackTime = 0f;
     [SerializeField] public float attackRate = 1f;

     public GameObject dmgText;

     public float ballDamagePrint = 1;
     public float fireDamagePrint = 1;
     public GameObject expSparkle;

     public bool isOnFire;

     public ParticleSystem fire;

    public int burnChance;

    public const float normalEnemyDamageDivider = 50;

    public const int minBurnChanceRange = 0;
    public const int maxBurnChanceRange = 101;

    public const float ballSkillDamage = 2;

    public const float burnDamage = 0.05f;

    public const float  burnCooldown = 6f;

    public float maxHp;
     

     

    

     

     

     public Action<Enemy> OnDeath;

    
    // Start is called before the first frame update
    void Start()
    {
       enemyHp = maxHp;

        

        

        

        GameMaster.instance.damageToPrint = PlayerM.instance.enemyDamage;

        GameMaster.instance.damageText.text =  GameMaster.instance.damageToPrint.ToString();
         
       
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
         
       
         
         transform.LookAt(GameMaster.instance.playerTransform.position);
         
         if(Time.time>=nextAttackTime){
         enemyShooting();
         nextAttackTime=Time.time+1/attackRate;
         }

        
         

         

         



         

          
        
         
    }


    public virtual void  TakeDamage(float damage){
        enemyHp -= damage;
         enemyHpImage.fillAmount = enemyHp/maxHp;
        Instantiate(dmgText,transform.position,dmgText.transform.rotation);
        if(enemyHp <= 0)
        {
            Destroy(gameObject);
         }

        
    }

   public void OnDestroy(){
   
    OnDeath?.Invoke(this);
     if(WaveManeger.instance.reLevel == false){
     Instantiate(expSparkle,transform.position,expSparkle.transform.rotation);
    }
      
   }
    

    public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == Bullet){
            TakeDamage(PlayerM.instance.enemyDamage);
        }
        

        if(other.gameObject.tag == FireBullet){
             TakeDamage(PlayerM.instance.enemyDamage);
              burnChance = UnityEngine.Random.Range(minBurnChanceRange,maxBurnChanceRange);
              if(burnChance > 70 && !isOnFire){
            isOnFire = true;
            fire.Play();
            StartCoroutine(FireDamage());
            StartCoroutine(StopFire());
              }
        }
         
    }

    public void OnTriggerEnter(Collider other){

        if(other.gameObject.tag == nameof(BallSkill)){
            GameMaster.instance.damageText.text = ballDamagePrint.ToString();
            TakeDamage(ballSkillDamage);
        }

    }


    private const string Bullet = "Bullet";
    public const string FireBullet = "FireBullet";
    //private const string BallSkill = "BallSkill";


    public void enemyShooting(){
        Instantiate(enemyBullet,enemyGun.position,transform.rotation);

    }

    public IEnumerator FireDamage(){
         while(isOnFire){
        GameMaster.instance.damageText.text = fireDamagePrint.ToString();
        TakeDamage(burnDamage);
         yield return new WaitForSeconds(1f);
         }
     }
    public IEnumerator StopFire(){
        if(isOnFire){
    yield return new WaitForSeconds(burnCooldown);
    fire.Stop();
    isOnFire = false;
        }
         
     }

    
   

        


        

        

}
