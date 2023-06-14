using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCat : MonoBehaviour
{
    private int _horizontalMove;
    private int _verticalMove;
    private int _speed = 1;

    private void Start()
    {
        gameObject.SetActive(true);
        _horizontalMove = ConvertRandomValueInDirectionMove();
        _verticalMove = ConvertRandomValueInDirectionMove();

        StartCoroutine(StartLive());
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _horizontalMove, _speed * Time.deltaTime * _verticalMove, 0);
    }

    public int ConvertRandomValueInDirectionMove()
    {
        int directionCount;
        int directMove = 1;
        int reversMove = -1;
        int countReversMove = 2;

        if (Random.Range(0, countReversMove) == 0)
        {
            directionCount = reversMove;
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