using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class MyCubeController : MonoBehaviour
{
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private float _speedTransit = 3.5f;
    [SerializeField] private float _multiplier;

    private AudioSource _audioSource;
    private float _maxDistance = 0.1f;
    private bool _mooveToRight = true;
    private float _pastRealTime;

    public int Score { get; private set; }

    public event UnityAction Dying;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.enabled = false;
    }

    private void Update()
    {
        _pastRealTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            _mooveToRight = !_mooveToRight;
        }

        if (Vector2.Distance(this.transform.position, _leftPoint.transform.position) <= _maxDistance)
        {
            _mooveToRight = true;
        }

        if (Vector2.Distance(this.transform.position, _rightPoint.transform.position) <= _maxDistance)
        {
            _mooveToRight = false;
        }
        if (_pastRealTime >= 3)
        {
            _pastRealTime = 0;
            _speedTransit += _multiplier;
            if (_speedTransit >= 6f)
            {
                _speedTransit = 6f;
            }
        }

        if (_mooveToRight)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, _rightPoint.transform.position, _speedTransit * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, _leftPoint.transform.position, _speedTransit * Time.deltaTime);
        }
    }






    public void ToScore()
    {
        Score++;
        ScoreChanged?.Invoke(Score);
        _audioSource.enabled = true;
        _audioSource.Play();
        Debug.Log(Score);
    }

    public void Die()
    {
        Dying?.Invoke();
        Time.timeScale = 0;
        Destroy(gameObject);
    }

}
