using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeleeEnemy : MonoBehaviour
{
  public float dis;
  public float enemySpeed = 2;
   Rigidbody enemyBody;
    PlayerM playerScript;
    public Transform player;
    public Image enemyHpImage;
    public float enemyHp;
     [SerializeField] private float nextAttackTime = 0f;
     [SerializeField] private float attackRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemyHpImage.fillAmount;
        enemyBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHpImage.fillAmount = enemyHp;
         dis  = Vector3.Distance(transform.position,player.position);
         if(enemyHp <= 0){
            Destroy(gameObject);
            GameMaster.instance.exp += 0.2f;
         }


         transform.LookAt(player);

         transform.position = Vector3.MoveTowards(transform.position,GameMaster.instance.player.position,enemySpeed * Time.deltaTime);

         

   
         
         
    }


    public void TakeDamage(float damage){
        enemyHp -= damage;
        
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Bullet"){
            // TakeDamage(playerScript.regulerBulletDamage);
            TakeDamage(0.01f);
            // isKnock = true;

            

        }

        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
        }

    }


   
}
