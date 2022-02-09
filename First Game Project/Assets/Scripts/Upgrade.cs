using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public EnemyManager enemyManager;
    public void SpeedUp()
    {
        enemyManager.spawnRate *= 0.5f;
    }

    public static Upgrade Instance;


}
