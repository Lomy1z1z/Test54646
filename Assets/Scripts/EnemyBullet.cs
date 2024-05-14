using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody bulletBody;
    [SerializeField]float enemyBulletSpeed = 5;
    Enemy enemy;
    float lifespan;
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

          if(lifespan > 2){
            Destroy(gameObject);
        }

        
    }


     public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy" ){
            Destroy(gameObject);
        }
    }
}
