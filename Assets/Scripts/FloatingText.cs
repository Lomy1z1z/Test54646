using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{

    public const float FloatingTextDestroyDelay = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,FloatingTextDestroyDelay);
    }

   
}
