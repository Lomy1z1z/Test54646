using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float dis;
    PlayerM playerScript;
    public Transform player;
    public Image enemyHpImage;
    public float enemyHp;
    GameMaster gm;
    public GameObject enemyBullet;
    public Transform enemyGun;
     [SerializeField] private float nextAttackTime = 0f;
     [SerializeField] private float attackRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemyHpImage.fillAmount;
        gm = FindObjectOfType<GameMaster>();
        playerScript = FindObjectOfType<PlayerM>();
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHpImage.fillAmount = enemyHp;
        //  dis  = Vector3.Distance(transform.position,player.position);
         
         transform.LookAt(player);
         
         if(Time.time>=nextAttackTime){
         enemyShooting();
         nextAttackTime=Time.time+1/attackRate;
         }
    }


    public void TakeDamage(float damage){
        enemyHp -= damage;

        if(enemyHp <= 0)
        {
            Destroy(gameObject);
            gm.exp += 0.2f;
         }

        
    }

    public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == Bullet){
            TakeDamage(playerScript.regulerBulletDamage);
        }
    }

    private const string Bullet = "Bullet";


    public void enemyShooting(){
        Instantiate(enemyBullet,enemyGun.position,transform.rotation);

    }
}
