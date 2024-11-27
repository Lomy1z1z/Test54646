using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    public Rigidbody bulletBody;
    [SerializeField]float enemyBulletSpeed = 5;
     public Enemy enemy;

     public const float  enemyBulletDestroyDelay = 1.8f;
    

    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,enemyBulletDestroyDelay);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bulletBody.AddForce(transform.forward * enemyBulletSpeed * Time.deltaTime);
        

          

        
    }


    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "ShieldSkill"){
            Destroy(gameObject);
        }
    }


     public override void Hit(GameObject other)
     {
        base.Hit(other);

     }
}
