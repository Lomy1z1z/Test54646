using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerM : MonoBehaviour
{
    [SerializeField] public Rigidbody player;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float runspeed = 5;
    [SerializeField] Transform gun1;
    [SerializeField] Transform gun2;
    [SerializeField] Transform gun3;
    [SerializeField] GameObject bullet;
    public Transform target;
    public float regulerBulletDamage = 0.4f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
     public float hp = 100;
    public Image hpImage;
    public float dashForce = 500;
    public float dashTimer;
    private bool isDashing = false;
    public bool tripleShot;
    
    
    

    
    
    
    
    

     [SerializeField] private float nextAttackTime = 0f;
     [SerializeField] private float attackRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {

        
       
        


        
        // Find all enemy objects in the scene
        // List to store all enemy and melee enemy GameObjects
        List<GameObject> allEnemies = new List<GameObject>();
         GameObject[] meleeEnemies = GameObject.FindGameObjectsWithTag("MeleeEnemy");
        allEnemies.AddRange(meleeEnemies); // Replace "Enemy" with the tag you use for the enemy objects

         GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        allEnemies.AddRange(enemies);


        // Initialize the closest distance as a large value
        float closestDistance = Mathf.Infinity;

        foreach (GameObject obj in allEnemies)
        {
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
            float targetAngle =Mathf.Atan2(diraction.x,diraction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0,angle,0);
        }

       

        player.velocity = new Vector3(horizontalMove,0,verticalMove);
        

        

        if(Time.time>=nextAttackTime && horizontalMove == 0 && verticalMove == 0 && target != null &&  tripleShot == false){
        Shooting();
         nextAttackTime=Time.time+1/attackRate;
         }

        if(Time.time>=nextAttackTime && horizontalMove == 0 && verticalMove == 0 && target != null && tripleShot == true){
        tripleShooting();
         nextAttackTime=Time.time+1/attackRate;
         }

         

        //   if(hp == 0)
        //   {
        //       SceneManager.LoadScene(0);

        //   }


         
           
         

        
    }

    public void Shooting(){
        if(target != null){
         transform.LookAt(target);
        Instantiate(bullet,gun1.position,transform.rotation);
        }   
    }

    public void tripleShooting(){
        if(target != null){
         transform.LookAt(target);
        Instantiate(bullet,gun1.position,transform.rotation);
        Instantiate(bullet,gun2.position,gun2.transform.rotation);
        Instantiate(bullet,gun3.position,gun3.transform.rotation);
        
        }   
    }

    public void TakeDamage(float damage){
        hp -= damage;
         hpImage.fillAmount = hp/100;
        
    }

    public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == enemyBall  && hp > 0 || other.gameObject.tag == Enemy && hp > 0 || other.gameObject.tag == MeleeEnemy && hp > 0 ){
            TakeDamage(10f);
            
        }

       
    }

    private const string enemyBall = "enemyBall";
    private const string Enemy = "Enemy";
    private const string MeleeEnemy = "MeleeEnemy";



  

    
            
        
    }
    

   

    


    

    


    

    


    

