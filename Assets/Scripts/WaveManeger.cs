using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManeger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]  GameObject enemy;
    [SerializeField]  List<Transform> Spowns = new List<Transform>();

    void Start()
    {
         //Instantiate(enemy,Spowns[0].position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

         int enemys = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        if(GameMaster.instance.killCount == 1 && enemys == 0){
            Instantiate(enemy,Spowns[0].position,transform.rotation);
            Instantiate(enemy,Spowns[1].position,transform.rotation);
        }
        if(GameMaster.instance.killCount == 3 && enemys == 0 ){
            Instantiate(enemy,Spowns[0].position,transform.rotation);
            Instantiate(enemy,Spowns[1].position,transform.rotation);
            Instantiate(enemy,Spowns[2].position,transform.rotation);
        }
        if(GameMaster.instance.killCount == 6  && enemys == 0){
            Instantiate(enemy,Spowns[0].position,transform.rotation);
            Instantiate(enemy,Spowns[1].position,transform.rotation);
            Instantiate(enemy,Spowns[2].position,transform.rotation);
            Instantiate(enemy,Spowns[3].position,transform.rotation);
        }
        
    }
}
