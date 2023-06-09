using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemysSpawn : MonoBehaviour
{
    [SerializeField] private EnemyCat _enemy;

    private GameObject [] _spawnPoints;

    void Start()
    {
        StartCoroutine(SpawnEnemy());       
    }

    private IEnumerator SpawnEnemy()
    {
        int waitingInSeconds = 1;

        _spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

        while (true)
        {
            Initialized(_enemy);
            yield return new WaitForSeconds(waitingInSeconds);
        }      
    }

    private void Initialized(EnemyCat newEnemy)
    {
        GameObject point = SelectRandomPoint(_spawnPoints);

        newEnemy = Instantiate(newEnemy, new Vector2(point.transform.position.x, point.transform.position.y), Quaternion.identity);
    }

    private GameObject SelectRandomPoint(GameObject [] spawnList)
    {
        int _randomPointNumber = Random.Range(0, spawnList.Length);
        
        GameObject point = spawnList[_randomPointNumber];
        return point;
    }
}
