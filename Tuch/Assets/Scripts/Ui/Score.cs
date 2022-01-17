using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private MyCubeController _myCubeController;
    [SerializeField] private TMP_Text _text;
     private Animator _anim;

    private void OnEnable()
    {
        _myCubeController.ScoreChanged += ScoreToText;
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _text.alpha = 0;
    }

    private void OnDisable()
    {
        _myCubeController.ScoreChanged -= ScoreToText;
    }

    private void ScoreToText(int score)
    {
        _text.alpha = 1;
        _text.text = score.ToString();
        _anim.Play("UpPoint");
        
    }
}
