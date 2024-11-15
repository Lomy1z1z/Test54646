using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject bomb;

    

    public float bombRate;

    public float nextBombTime;

    public ParticleSystem boom;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemyHpImage.fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHpImage.fillAmount = enemyHp;
         transform.LookAt(GameMaster.instance.playerTransform);

          if(Time.time>=nextAttackTime){
         enemyShooting();
         nextAttackTime=Time.time+1/attackRate;
         }
         
          if(Time.time>=nextBombTime){
         boom.Play();
         BombShooting();
         nextBombTime=Time.time+1/bombRate;
          }
         
         
    }


    public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == Bullet){
            TakeDamage(PlayerM.instance.enemyDamege/200);
        }

        if(other.gameObject.tag == FireBullet){
             TakeDamage(PlayerM.instance.enemyDamege/200);
              burnChance = UnityEngine.Random.Range(0,101);
              if(burnChance > 70 && !isOnFire){
            isOnFire = true;
            fire.Play();
            StartCoroutine(FireDamage());
            StartCoroutine(StopFire());
              }
        }

    }

     public void BombShooting(){
             Instantiate(bomb,GameMaster.instance.bombTransform.position,transform.rotation);

        }

        


    

    


     private const string Bullet = "Bullet";
    public const string FireBullet = "FireBullet";
}
