using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _spawnPoint1;
    [SerializeField] private GameObject _spawnPoint2;
    [SerializeField] private GameObject _spawnPoint3;
    [SerializeField] private GameObject _spawnPoint4;
    [SerializeField] private GameObject _spawnPoint5;

    void Start()
    {
        StartCoroutine(SpawnEnemy());       
    }

    private IEnumerator SpawnEnemy()
    {
        int waitingInSeconds = 2;

        List<GameObject> _spawnList = new List<GameObject>()
        { _spawnPoint1, _spawnPoint2, _spawnPoint3, _spawnPoint4, _spawnPoint5};
 
        while (true)
        {
            GameObject point = SelectRandomPoint(_spawnList);
            GameObject newEnemy = Instantiate(_enemy, new Vector2(point.transform.position.x, point.transform.position.y), Quaternion.identity);

            yield return new WaitForSeconds(waitingInSeconds);
        }      
    }

    private GameObject SelectRandomPoint(List<GameObject> spawnList)
    {
        int _randomPointNumber = Random.Range(0, spawnList.Count);
        
        GameObject point = spawnList[_randomPointNumber];
        return point;
    }
}
