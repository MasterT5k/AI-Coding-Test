using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Material _mat;
    private Color _orignalColor;

    private void OnEnable()
    {
        EnemyPool.enemies.Add(this);
    }

    private void OnDisable()
    {
        EnemyPool.enemies.Remove(this);
    }

    private void Awake()
    {
        _mat = GetComponent<Renderer>().material;
        _orignalColor = _mat.color;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(EnemyPool.enemies.Count);
    }    

    public void ChangeColor(Color color, bool changeBack = false)
    {
        if (changeBack == true)
        {
            _mat.color = _orignalColor;
        }
        else
        {
            _mat.color = color;
        }
    }
}
