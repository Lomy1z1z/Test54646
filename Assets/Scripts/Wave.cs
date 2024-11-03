using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wave : MonoBehaviour
{

    
     
    [Serializable]
    public class WaveZ
    {
        public List<Enemy> EnemiesToSpawn;  // List of enemies to spawn in this wave
        public List<Transform> SpawnPoints;      // List of spawn points for this wave
        public bool IsCompleted;                 // Track if the wave is completed
    }

    // List of multiple waves
    [SerializeField]
    public List<WaveZ> waves = new List<WaveZ>();

    

    

    


   


    


     

    
}
