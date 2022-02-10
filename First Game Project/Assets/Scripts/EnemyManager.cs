using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private int[] Xrandom = new int[5];

    public float spawnRate;
    public GameObject enemyPref;

    private void Start()
    {
        spawnRate = 2.0f;
        Xrandom[0] = -4;
        Xrandom[1] = -2;
        Xrandom[2] = 0;
        Xrandom[3] = 2;
        Xrandom[4] = 4;
        StartCoroutine("CreateEnemy");
    }

    // ���� z=20f���� ������ ��ġ�� ��ȯ�Ѵ�.
    IEnumerator CreateEnemy()
    {
        while (true)
        {
            Instantiate<GameObject>(enemyPref, GenerateRandomPosition, Quaternion.AngleAxis(180f, Vector3.up));
            yield return new WaitForSeconds(spawnRate);

        }
    }

    // ������ x�� ���� �����Ѵ�.
    Vector3 GenerateRandomPosition
    {
        get
        {
            int xPos = Xrandom[Random.Range(0, Xrandom.Length)];
            Vector3 randomPos = new Vector3(xPos, 0, 10);
            return randomPos;

        }
    }
    //Vector3 GenerateRandomSpawnPosition
    //{
    //    get
    //    {
    //        Xrandom = Random.Range(-5, 5);
    //        Vector3 randomPos = new Vector3(Xrandom, 0, 20);
    //        return randomPos;

    //    }
    //}


}
