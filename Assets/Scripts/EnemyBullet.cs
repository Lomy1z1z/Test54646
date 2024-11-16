using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    Rigidbody bulletBody;
    [SerializeField]float enemyBulletSpeed = 5;
    Enemy enemy;
    float lifespan;

    private const int maximumLifespan = 2;

    // Start is called before the first frame update
    void Start()
    {
        bulletBody = GetComponent<Rigidbody>();
        enemy = FindObjectOfType<Enemy>();
        lifespan = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bulletBody.AddForce(transform.forward * enemyBulletSpeed * Time.deltaTime);
        lifespan += Time.deltaTime;

          if(lifespan > maximumLifespan){
            Destroy(gameObject);
        }

        
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
