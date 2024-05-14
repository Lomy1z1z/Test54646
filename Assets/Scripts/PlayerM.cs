using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerM : MonoBehaviour
{
    public Rigidbody player;
    public Joystick joystick;
    public float runspeed = 5;
    [SerializeField] Transform gun;
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

    
    
    //public Enemy enemy;
    
    

     [SerializeField] private float nextAttackTime = 0f;
     [SerializeField] private float attackRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        
        //enemy = FindObjectOfType<Enemy>();
        

    }

    // Update is called once per frame
    void Update()
    {

        
       
        


        
        // Find all enemy objects in the scene
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); // Replace "Enemy" with the tag you use for the enemy objects

        // Initialize the closest distance as a large value
        float closestDistance = Mathf.Infinity;

        foreach (GameObject obj in enemys)
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

        

        if(Time.time>=nextAttackTime && horizontalMove == 0 && verticalMove == 0 && target != null){
        Shooting();
         nextAttackTime=Time.time+1/attackRate;
         }

         if(Input.GetKeyDown(KeyCode.Space) && horizontalMove != 0 && verticalMove != 0){
            isDashing = true;
         }

         if(isDashing == true && horizontalMove != 0 && verticalMove != 0){

            dashTimer += Time.deltaTime;
             
         player.AddForce(transform.forward * dashForce * Time.deltaTime);

         }

         if(dashTimer > 0.3f){
            isDashing  = false;
            dashTimer = 0;
         }


         //transform.LookAt(target);

         

         

        
    }

    public void Shooting(){
        if(target != null){
        Instantiate(bullet,gun.position,transform.rotation);
         transform.LookAt(target);
        
        }
        
         
    }

    public void TakeDamage(float damage){
        hp -= damage;
         hpImage.fillAmount = hp/100;
        
    }

    public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "enemyBall" && hp > 0){
            TakeDamage(10f);
            Debug.Log(hp);
        }

       
    }


    public void Dash(){

        isDashing = true;
       
    }

   

    


    

    


    

    


    
}
