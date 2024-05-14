using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody bullet;
    public float bulletSpeed = 10;
    public PlayerM player;
    public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerM>();
       
        
    }

    // Update is called once per frame
    void Update()
    {

        
       transform.position =  Vector3.MoveTowards(transform.position,player.target.position,bulletSpeed * Time.deltaTime);
       //bullet.AddForce(transform.forward * bulletSpeed * Time.deltaTime);
        
    }

    public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Enemy"){
            Destroy(gameObject);
        }
    }
}
