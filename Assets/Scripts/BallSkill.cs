using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSkill : MonoBehaviour
{
   public Transform target;
   public float ballSpeed;

   public float raduis;

   public float angle = 0;

    // Update is called once per frame
    void Update()
    {

        float x =target.position.x + Mathf.Cos(angle) * raduis;

        float y =target.position.y;

        float z =target.position.z + Mathf.Sin(angle) * raduis;


        transform.position = new Vector3(x,y,z);


        angle += ballSpeed * Time.deltaTime;
    }
}
