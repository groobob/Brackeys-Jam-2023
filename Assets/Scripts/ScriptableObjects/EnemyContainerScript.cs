using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyContainerScript : ScriptableObject
{
    public int speed;
    
    public string EnemyName;
    public bool canShoot;
    public bool hasSpikes;
    public bool deathTouch;
}
