using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D wheel;
    [SerializeField] bool isSpinning = false;

    float maxSpin = 0;

    float quortAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isSpinning == true){
            wheel.AddTorque(quortAmount,ForceMode2D.Impulse);
            maxSpin ++;
        }

        if(maxSpin >= 500){
            isSpinning = false;
            wheel.constraints = RigidbodyConstraints2D.FreezeRotation;
            maxSpin = 0;
        }

        if(maxSpin < 1){
            wheel.constraints = RigidbodyConstraints2D.None;
        }
        

       
        
    }


    public void Spin(){
        isSpinning = true;
    }
}
