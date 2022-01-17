using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private float _speedTransit;
    [SerializeField] private float _minDistanse;


    private bool _isToPoint2 = true;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isToPoint2 = !_isToPoint2;
        }

        if (Vector2.Distance(this.transform.position, _rightPoint.transform.position) <= _minDistanse)
        {
            _isToPoint2 = false;
        }

        if(Vector2.Distance(this.transform.position, _leftPoint.transform.position) <= _minDistanse)
        {
            _isToPoint2 = true;
        }

        if (_isToPoint2)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, _rightPoint.transform.position, _speedTransit * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, _leftPoint.transform.position, _speedTransit * Time.deltaTime);
        }
    }   
}
