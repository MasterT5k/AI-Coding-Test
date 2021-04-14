using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody))]
public class Detection : MonoBehaviour
{
    [SerializeField]
    private float _searchDelay = 0.1f;
    [SerializeField]
    private bool _lookForEnemies = true;
    private bool _searchForClosest = false;
    private WaitForSeconds _detectDelay;
    [SerializeField]
    private Enemy _closestEnemy = null;
    [SerializeField]
    private Color _closestEnemyColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        _detectDelay = new WaitForSeconds(_searchDelay);
        if (_lookForEnemies == true)
        {
            _searchForClosest = true;
            StartCoroutine(DetectEnemiesRoutine());
        }
    }

    //private void FixedUpdate()
    //{
    //    var enemy = EnemyPool.FindClosestEnemy(transform.position);
    //    if (_closestEnemy == null)
    //    {
    //        _closestEnemy = enemy;
    //        _closestEnemy.ChangeColor(_closestEnemyColor);
    //    }
    //    else if (_closestEnemy != enemy)
    //    {
    //        _closestEnemy.ChangeColor(_closestEnemyColor, true);
    //        _closestEnemy = enemy;
    //        _closestEnemy.ChangeColor(_closestEnemyColor);
    //    }
    //}

    IEnumerator DetectEnemiesRoutine()
    {
        while (_searchForClosest == true)
        {
            var enemy = EnemyPool.FindClosestEnemy(transform.position);
            if (_closestEnemy == null)
            {
                _closestEnemy = enemy;
                _closestEnemy.ChangeColor(_closestEnemyColor);
            }
            else if (_closestEnemy != enemy)
            {
                _closestEnemy.ChangeColor(_closestEnemyColor, true);
                _closestEnemy = enemy;
                _closestEnemy.ChangeColor(_closestEnemyColor);
            }

            yield return _detectDelay;
        }
    }
}
