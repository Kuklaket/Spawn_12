using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCat : MonoBehaviour
{
    private Vector2 _vectorMove = new Vector2();   
    private int _speed = 1;

    private void Start()
    {
        gameObject.SetActive(true);
        ConvertValueInDirection();

        StartCoroutine(StartLive());
    }

    private void Update()
    {
        transform.Translate(_vectorMove.normalized * _speed * Time.deltaTime);
    }

    private void ConvertValueInDirection()
    {
        _vectorMove.x = GetDirection();

        do
        {
            _vectorMove.y = GetDirection();

        } while (_vectorMove.x == 0 && _vectorMove.y == 0);
    }

    private int GetDirection()
    {
        int directionCount;
        int directMove = 1;
        int reversMove = -1;
        int countReversMove = 2;
        int randomValue = Random.Range(reversMove, countReversMove);

        if (randomValue == reversMove)
        {
            directionCount = reversMove;
        }
        else if (randomValue == 0)
        {
            directionCount = 0;
        }
        else
        {
            directionCount = directMove;
        }

        return directionCount;
    }

    private IEnumerator StartLive()
    {
        int liveLenght = 3;
              
        yield return new WaitForSeconds(liveLenght);
        Destroy(gameObject);
    }
}