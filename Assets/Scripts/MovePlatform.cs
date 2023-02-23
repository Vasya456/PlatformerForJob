using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private int _currentPoint;

    [SerializeField] private Transform _platform;
    
    void Start()
    {
        
    }

  

    void Update()
    {
        _platform.position = Vector3.MoveTowards(_platform.position, _points[_currentPoint].position, _speed * Time.deltaTime);

        if (Vector3.Distance(_platform.position, _points[_currentPoint].position) < .05f) 
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length) 
            {
                _currentPoint = 0;
            }
        }
    }
}
