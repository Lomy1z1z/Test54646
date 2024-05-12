using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    public Rigidbody player;
    public Joystick joystick;
    public float runspeed = 5;
    [SerializeField] Transform gun;
    [SerializeField] GameObject bullet;
    public Transform target;
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

        player.velocity = new Vector3(horizontalMove,0,verticalMove);

        if(Time.time>=nextAttackTime && horizontalMove == 0 && verticalMove == 0){
        Shooting();
         nextAttackTime=Time.time+1/attackRate;
         }
         transform.LookAt(target);

         

        
    }

    public void Shooting(){
        if(target != null){
        Instantiate(bullet,gun.position,transform.rotation);
        
        }
        
         
    }


    

    


    
}
