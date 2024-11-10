using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody bullet;
    public float bulletSpeed = 10;
    public Transform playerPos;
    public List<string>  tags;

    //public ParticleSystem fire;
    public static Bullet instance; 
    // Start is called before the first frame update
    void Start()
    {

        
        instance = this;
        Destroy(gameObject,1f);

        
    }

    // Update is called once per frame
    void Update()
    {

        
    //    transform.position =  Vector3.MoveTowards(transform.position,player.target.position,bulletSpeed * Time.deltaTime);
       bullet.AddForce(transform.forward * bulletSpeed * Time.deltaTime);
        
    }

    public void OnCollisionEnter(Collision other){
        if(HitCheck(other.gameObject.tag)){
           Hit(other.gameObject);
        }
    }


    public virtual void Hit(GameObject target)
    {
        Destroy(gameObject);


    }

    private bool HitCheck(string objTag){
         return tags.Contains(objTag);
         
        
    }
}
