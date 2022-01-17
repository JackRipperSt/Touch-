using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FallingCubesController : MonoBehaviour
{
    [SerializeField] protected Vector3 _targetPoint;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _minRotationSpeed;
    [SerializeField] protected float _maxRotationSpeed;
    [SerializeField] protected float _multiplier;
    protected Vector3 _rotateDir;
    protected float _pastRealTime;
    protected Animator _anim;
    protected BoxCollider2D _boxCollider2D;

    //protected abstract void PlayAnim();
   // protected abstract void PreparationForDestroy();
    



}
