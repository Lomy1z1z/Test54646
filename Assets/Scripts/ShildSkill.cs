using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildSkill : MonoBehaviour
{
    public SphereCollider shlidCollider;
    public MeshRenderer shildRenderer;

    public float ShildCooldown = 60; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       

        
    }

    public void OnTriggerEnter(Collider other){

        if(other.gameObject.tag == enemyBall || other.gameObject.tag == MeleeEnemy ){
            shlidCollider.enabled = false;
            shildRenderer.enabled = false;
            StartCoroutine(ResetShild());
        }

    }


  
 IEnumerator ResetShild(){
         yield return new WaitForSecondsRealtime(ShildCooldown);
         shlidCollider.enabled = true;
         shildRenderer.enabled = true;
         
     }
        

    private const string enemyBall = "enemyBall";
     private const string MeleeEnemy = "MeleeEnemy";
}
