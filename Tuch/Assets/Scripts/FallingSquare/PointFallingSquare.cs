using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PointFallingSquare : FallingCubesController
{
    
    private void Awake()
    {
        _targetPoint = new Vector3(Random.Range(-2f, 2f), transform.position.y - 13, 0f);
        _rotateDir = new Vector3(0f, 0f, Random.Range(-_minRotationSpeed, +_maxRotationSpeed));
        //_speed = 4f;
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.enabled = false;
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _pastRealTime += Time.deltaTime;

        this.transform.position = Vector2.MoveTowards(this.transform.position, _targetPoint, _speed * Time.deltaTime);
        this.transform.rotation *= Quaternion.Euler(_rotateDir * Time.deltaTime);

       /* if(_pastRealTime >= 5)
        {
            _pastRealTime = 0;
            _speed += _multiplier;
            if(_speed >= 7)
            {
                _speed = 7f;
            }
        }*/
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MyCubeController>(out MyCubeController _myCubeController))
        {
            _myCubeController.ToScore();
            PlayAnim();
            PreparationForDestroy();
        }
    }


    private void PlayAnim()
    {
        _anim.enabled = true;
        _anim.Play("Die");
    }

    private void PreparationForDestroy()
    {
        _boxCollider2D.enabled = false;
        _speed = 2f;
        Destroy(gameObject,0.5f);

    }
}
