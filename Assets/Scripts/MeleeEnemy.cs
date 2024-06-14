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
    GameMaster gm;
    public bool isKnock;
    public bool iSchase;
    public float knockAmount;
     [SerializeField] private float nextAttackTime = 0f;
     [SerializeField] private float attackRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemyHpImage.fillAmount;
        gm = FindObjectOfType<GameMaster>();
        playerScript = FindObjectOfType<PlayerM>();
        enemyBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHpImage.fillAmount = enemyHp;
         dis  = Vector3.Distance(transform.position,player.position);
         if(enemyHp <= 0){
            Destroy(gameObject);
            gm.exp += 0.2f;
         }
         transform.LookAt(player);

         
         transform.position = Vector3.MoveTowards(transform.position,playerScript.player.position,enemySpeed * Time.deltaTime);
         
          

         if(isKnock)
         {
            knockAmount = 100;
            StartCoroutine(KnockEnemy());
         enemyBody.AddForce(transform.forward * - knockAmount);
         }
         else{
            knockAmount =

         }

         
         
         
    }


    public void TakeDamage(float damage){
        enemyHp -= damage;
        
    }

    public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Bullet"){
            TakeDamage(playerScript.regulerBulletDamage);

            isKnock = true;

        }

        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
        }

    }

     IEnumerator KnockEnemy()
    {
        // Wait for 0.5 seconds before shooting
        yield return new WaitForSeconds(0.01f);

        // Call the Shooting method
        isKnock = false;
    }

    // public void OnTriggerStay(Collider other){
    //     if(other.gameObject.tag == "Player"){
    //     iSchase = true;
    //     }
    // }
    // public void OnTriggerExit(Collider other){
    //     if(other.gameObject.tag == "Player"){
    //     iSchase = false;
    //     }
    // }

    


   
}
