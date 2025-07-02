using System;
using System.Collections;
using UnityEngine;

public class EnemyCat : MonoBehaviour
{
    private Vector2 _vectorMove;   
    private int _speed = 1;

    public event Action<EnemyCat> ReadyForRelease;

    private void OnEnable()
    {
        StartCoroutine(StartLive());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        transform.Translate(_vectorMove.normalized * _speed * Time.deltaTime);
    }

    private IEnumerator StartLive()
    {
        int liveLenght = 5;

        yield return new WaitForSeconds(liveLenght);
        ReadyForRelease?.Invoke(this);
    }

    public void SetDirection(Vector2 direction)
    {
        _vectorMove = direction;
    }
}