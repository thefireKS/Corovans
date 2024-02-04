using UnityEngine;

namespace Corovans.Scripts
{
    public class WagonManager : MonoBehaviour
    {
       [field:SerializeField] public GameObject WagonPrefab { get; private set; }
       [field:SerializeField] public GameObject MarksmanPrefab { get; private set; }
       [field:SerializeField] public GameObject HorsePrefab { get; private set; }

       private void Awake()
       {
           Initialize();
       }

       public void Initialize()
       {
           Instantiate(WagonPrefab, transform);
           var defenderSpawnPoints =
               GameObject.Find("Defenders Spawn Points").transform.GetComponentsInChildren<Transform>();
           for (int i = 1; i < defenderSpawnPoints.Length; i++)
           {
               Instantiate(MarksmanPrefab, defenderSpawnPoints[i]); 
           }
           Instantiate(HorsePrefab, GameObject.Find("Horse Spawn Point").transform);
       }
    }
}
