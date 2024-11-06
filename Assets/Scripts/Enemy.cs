using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

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

     public GameObject dmgText;

     public float ballDamagePrint = 1;

     

    

     

     

     public Action<Enemy> OnDeath;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemyHpImage.fillAmount;

        

        

        

        GameMaster.instance.damageToPrint = PlayerM.instance.enemyDamege;

        GameMaster.instance.damageText.text =  GameMaster.instance.damageToPrint.ToString();
         
       
        
        
        
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
        Instantiate(dmgText,transform.position,dmgText.transform.rotation);
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
            TakeDamage(PlayerM.instance.enemyDamege/50);
            Debug.Log(PlayerM.instance.enemyDamege);

        }
         
    }

    public void OnTriggerEnter(Collider other){

        if(other.gameObject.tag == BallSkill){
            GameMaster.instance.damageText.text = ballDamagePrint.ToString();
            TakeDamage(0.2f);
        }

    }


    private const string Bullet = "Bullet";
    private const string BallSkill = "BallSkill";


    public void enemyShooting(){
        Instantiate(enemyBullet,enemyGun.position,transform.rotation);

    }

    
   

        


        

        

}
