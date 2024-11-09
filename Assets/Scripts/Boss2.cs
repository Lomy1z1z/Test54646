using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MeleeEnemy
{

    [SerializeField] Rigidbody bossEnemyBody;
    [SerializeField]  float bossEnemySpeed;

    public GameObject finishCamera;

    public bool isDead = false;

    public GameObject playerCan;

    public float stop = 0;

    public ParticleSystem bossExpload;

    public MeshRenderer enemyMesh;
    public GameObject enemyMeshEYES;
    public MeshRenderer enemyMeshNOS1;
    public MeshRenderer enemyMeshNOS2;

    public GameObject winnerText;

    

    
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemyHpImage.fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
         bossEnemySpeed = 400;
        //knockForce = 1000;

         enemyHpImage.fillAmount = enemyHp;

        //  if(Time.time>=nextAttackTime){
        //  enemyShooting();
        //  nextAttackTime=Time.time+1/attackRate;
        //  }

         transform.LookAt(GameMaster.instance.playerTransform);

         Vector3 direction = (GameMaster.instance.playerTransform.position - transform.position).normalized;

         

         

          if(isDead == false){
        if(Time.time>=nextAttackTime){
         enemyShooting();
         nextAttackTime=Time.time+1/attackRate;
         }
            bossEnemyBody.velocity = direction * bossEnemySpeed * Time.fixedDeltaTime;
          }else{

            

            bossEnemyBody.velocity = direction * stop * Time.fixedDeltaTime;

            

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


     public void TakeDamage(float damage){
        enemyHp -= damage;
        Instantiate(dmgText,transform.position,dmgText.transform.rotation);
        if(enemyHp <= 0 && isDead == false)
        {
            isDead = true;
            finishCamera.SetActive(true);
            bossEnemyBody.isKinematic = false;
            isDead = true;
            PlayerM.instance.runspeed = 0;
             StartCoroutine(ExploadBoss());
             PlayerM.instance.attackRate = 0;
             PlayerM.instance.TakeDamage(0);
         }

        
    }


     IEnumerator ExploadBoss(){
        yield return new WaitForSeconds(3f);
        bossExpload.Play();
        yield return new WaitForSeconds(0.5f);
        enemyMesh.enabled = false;
        enemyMeshEYES.SetActive(false);
        enemyMeshNOS1.enabled = false;
        enemyMeshNOS2.enabled = false;
        Instantiate(winnerText,transform.position,transform.rotation);
        WaveManeger.instance.enemiesRemaning = 0;
        WaveManeger.instance. enemytext.text =  WaveManeger.instance.enemiesRemaning.ToString();
    }


     public void OnTriggerEnter(Collider other){

        if(other.gameObject.tag == BallSkill){
            GameMaster.instance.damageText.text = ballDamagePrint.ToString();
            TakeDamage(0.2f);
        }

    }


    private const string Bullet = "Bullet";
    public const string FireBullet = "FireBullet";
    public const string BallSkill = "FireBullet";
}



