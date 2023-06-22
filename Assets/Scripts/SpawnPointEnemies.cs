using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPointEnemies : MonoBehaviour
{
    [SerializeField] private EnemyCat _enemy;
    
    private List<Transform> _pointsSpawn = new();

    private void Start()
    {
        StartCoroutine(SpawnEnemy());       
    }

    private IEnumerator SpawnEnemy()
    {
        int waitingInSeconds = 2;
        var waitForSeconds = new WaitForSeconds(waitingInSeconds);

        FillList();
            
        while (true)
        {
            Initialized(_enemy);
            yield return waitForSeconds;
        }      
    }

    private void Initialized(EnemyCat newEnemy)
    {
        Transform point = SelectRandomPoint(_pointsSpawn);

        newEnemy = Instantiate(newEnemy, new Vector2(point.transform.position.x, point.transform.position.y), Quaternion.identity);
    }

    private Transform SelectRandomPoint(List<Transform> spawnList)
    {
        int _randomPointNumber = Random.Range(0, spawnList.Count);

        Transform point = spawnList[_randomPointNumber];
        return point;
    }

    private void FillList()
    {
       foreach (Transform spawn in transform)
        {
            _pointsSpawn.Add(spawn);
        }
    }
}
