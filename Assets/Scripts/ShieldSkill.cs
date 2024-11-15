using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildSkill : MonoBehaviour
{
    public SphereCollider shieldCollider;
    public MeshRenderer shieldRenderer;

    public float ShieldCooldown = 60; 
    
    
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
            shieldCollider.enabled = false;
            shieldRenderer.enabled = false;
            StartCoroutine(ResetShild());
        }

    }


  
 IEnumerator ResetShild(){
         yield return new WaitForSecondsRealtime(ShieldCooldown);
         shieldCollider.enabled = true;
         shieldRenderer.enabled = true;
         
     }
        

    private const string enemyBall = "enemyBall";
     private const string MeleeEnemy = "MeleeEnemy";
}
