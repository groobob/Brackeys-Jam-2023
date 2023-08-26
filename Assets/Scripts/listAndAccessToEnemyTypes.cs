using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listAndAccessToEnemyTypes : MonoBehaviour
{
    [SerializeField] List<EnemyContainerScript> enemyTypeList = new List<EnemyContainerScript>();
    // Start is called before the first frame update
    
    public EnemyContainerScript getEnemyType(int i)
    {
        return enemyTypeList[i];
    }

}
