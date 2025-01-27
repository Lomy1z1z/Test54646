using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerM : MonoBehaviour
{
    [SerializeField] public Rigidbody player;
    [SerializeField] private Joystick joystick;
    [SerializeField] public float runspeed = 5;
    [SerializeField] Transform gun1;
    [SerializeField] Transform gun2;
    [SerializeField] Transform gun3;
    [SerializeField] public GameObject bullet;
    public Transform target;
    public float regularBulletDamage = 0.4f;
     public float turnSmoothTime = 0.1f;
     public float turnSmoothVelocity;
     public float hp = 100;
    public Image hpImage;
    public Image hpImageBackground;
    
    public bool tripleShot;

    public Material Visible;

    public bool isVisble = true;

     public float enemyDamage = 1.5f;
    public static PlayerM instance; 

    public GameObject fireBullet;

    public Transform cam;

     public CinemachineFreeLook camera;

     public Animator animator;

     public float minDamage = 1;

     public float maxDamage = 10;

     public GameObject regulerBullet;

<<<<<<< Updated upstream
=======
     public const float hitInvisblityReset = 0.5f;
     
     public Data data;
>>>>>>> Stashed changes
     

     



   
    
    
    
    

    
    
    
    
    

     [SerializeField] private float nextAttackTime = 0f;
     [SerializeField] public float attackRate = 1f;



    

    // Start is called before the first frame update
    void Start()
    {

        
        
        Visible.SetColor("_Color", Color.blue);
        instance = this;
        RandomEnemyDamage();

    }

    // Update is called once per frame
    void Update()
    {

        


         float closestDistance = Mathf.Infinity;

       
        for (int i = WaveManeger.instance.enemies.Count - 1; i >= 0; i--){
             Enemy obj = WaveManeger.instance.enemies[i];

        
        // Initialize the closest distance as a large value
       
          // Calculate the distance between the current object and the player
          
    float distanceToPlayer = Vector3.Distance(obj.transform.position, player.position);

    // Update the target if the current object is closer to the player
    if (distanceToPlayer < closestDistance)
    {
        closestDistance = distanceToPlayer;
        target = obj.transform;
    }
    }

    
         var horizontalMove = joystick.Horizontal * runspeed;
         var verticalMove = joystick.Vertical * runspeed;

         
         

        Vector3 diraction = new Vector3(horizontalMove,0f,verticalMove).normalized;

        if(diraction.magnitude >=0.1f){
            float targetAngle =Mathf.Atan2(diraction.x,diraction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0,angle,0);
        }

       

        player.velocity = new Vector3(horizontalMove,0,verticalMove);

        if(horizontalMove !=0 || verticalMove!= 0){
            animator.SetBool("Run",true);
            animator.SetBool("Shooting",false);
        }else{
            animator.SetBool("Run",false);
        }


        if(target == null){
            animator.SetBool("Shooting",false);
        }
        


        if(Time.time>=nextAttackTime && horizontalMove == 0 && verticalMove == 0 && target != null &&  GameMaster.instance.inGameData.tripleShootData == false){
        Shooting();
         nextAttackTime=Time.time+1/attackRate;
         }

        

        if(Time.time>=nextAttackTime && horizontalMove == 0 && verticalMove == 0 && target != null && GameMaster.instance.inGameData.tripleShootData == true){
        tripleShooting();
         nextAttackTime=Time.time+1/attackRate;
         }

        
    }

    public void Shooting(){
        RandomEnemyDamage();
        GameMaster.instance.damageToPrint = Mathf.RoundToInt(enemyDamage);
        GameMaster.instance.damageText.text =  GameMaster.instance.damageToPrint.ToString();
        if(target != null){
        animator.SetBool("Shooting",true);
         transform.LookAt(target);
        Instantiate(GameMaster.instance.bulletType,gun1.position,transform.rotation);
        }   
    }
   

    public void tripleShooting(){
         RandomEnemyDamage();
        GameMaster.instance.damageToPrint = Mathf.RoundToInt(enemyDamage);
        GameMaster.instance.damageText.text =  GameMaster.instance.damageToPrint.ToString();
        if(target != null){
        animator.SetBool("Shooting",true);
         transform.LookAt(target);
        Instantiate(GameMaster.instance.bulletType,gun1.position,transform.rotation);
        Instantiate(GameMaster.instance.bulletType,gun2.position,gun2.transform.rotation);
        Instantiate(GameMaster.instance.bulletType,gun3.position,gun3.transform.rotation);
        
        }   
    }

    public void TakeDamage(float damage){
        hp -= damage;
         hpImage.fillAmount = hp/100;
         Visible.SetColor("_Color", Color.white);
         isVisble = false;
        
          if(hp <= 0){
              Time.timeScale = 0;
             WaveManeger.instance.menuImg.SetActive(true);
              WaveManeger.instance.finish = true;

          }
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == enemyBall  && hp > 0  && isVisble || other.gameObject.tag == Enemy && hp > 0  && isVisble || other.gameObject.tag == MeleeEnemy && hp > 0  && isVisble){
            TakeDamage(10f);
            StartCoroutine(ResetHit());
        }

        if(other.gameObject.tag == "exp" && WaveManeger.instance.enemiesRemaning == 0){
            Destroy(other.gameObject);
            GameMaster.instance.exp += GameMaster.instance.sparkleExpAmount;
        }

       
    }


    public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == Enemy && hp > 0   && isVisble || other.gameObject.tag == MeleeEnemy && hp > 0  && isVisble){
            TakeDamage(10f);
            StartCoroutine(ResetHit());
            
        }

       
    }

    private const string enemyBall = "enemyBall";
    private const string Enemy = "Enemy";
    private const string MeleeEnemy = "MeleeEnemy";

 IEnumerator ResetHit(){
         yield return new WaitForSeconds(0.5f);
          Visible.SetColor("_Color", Color.blue);
          isVisble = true;
         
     }

  

    

     public void RandomEnemyDamage(){

        enemyDamage = Random.Range(minDamage,maxDamage);

        
    }

    public void ResetPlayerPosition(){
        
    }
            
        
    }

   

    
    

   

    


    

    


    

    


    

