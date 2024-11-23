using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrroyExp : MonoBehaviour
{
    // Start is called before the first frame update

     [SerializeField] float objectDestroyDelay = 0.1f;
    void Start()
    {
        Destroy(gameObject,objectDestroyDelay );
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "exp"){
            Destroy(other.gameObject);
        }
    }
}
