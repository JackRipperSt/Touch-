using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class RestartMenuController : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private MyCubeController _myCubeController;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestart);
        _myCubeController.Dying += OnDying;
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _restartButton.interactable = false;
        _exitButton.interactable = false;
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestart);
    }


    public void OnRestart()
    {
        Time.timeScale= 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void OnDying()
    {
        _canvasGroup.alpha = 1;
        _restartButton.interactable = true;
        _exitButton.interactable = true;

    }
}
