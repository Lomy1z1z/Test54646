using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    
        public List<Transform> SpawnPoints;
		public List<GameObject> EnemiesToSpawn;
		
}
