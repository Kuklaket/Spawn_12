using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int _horizontalMove;
    private int _verticalMove;
    private int _speed = 1;

    private void Start()
    {
        gameObject.SetActive(true);
        _horizontalMove = Random.RandomRange(-1, 2);
        _verticalMove = Random.RandomRange(-1, 2);
        StartCoroutine(StartLive());
    }

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _horizontalMove, _speed * Time.deltaTime * _verticalMove, 0);
    }

    private IEnumerator StartLive()
    {
        int liveLenght = 3;
              
        yield return new WaitForSeconds(liveLenght);
        Destroy(gameObject);
    }
}