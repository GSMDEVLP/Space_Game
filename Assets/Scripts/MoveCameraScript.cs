using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private float _moveSpeed = 0.005f;
    private int _restrictions1 = 65;
    private int _restrictions2 = 60;
    private bool _flagMove = true;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_camera.fieldOfView <= _restrictions1 && _flagMove)
        {
            _camera.fieldOfView += _moveSpeed;
            if (Math.Round(_camera.fieldOfView) == _restrictions1)
                _flagMove = false;
        }
        
        
        if(_camera.fieldOfView <= _restrictions1 && !_flagMove)
        {
            _camera.fieldOfView -= _moveSpeed;
            if (Math.Round(_camera.fieldOfView) == _restrictions2)
                _flagMove = true;
        }

    }
}
