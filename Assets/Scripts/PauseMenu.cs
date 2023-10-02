using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    #region Fields and Properties

    private Canvas _settingsCanvas;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    #endregion

    #region Methods

    private void Start()
    {
        _settingsCanvas = GetComponent<Canvas>();
        _settingsCanvas.enabled = false;
        _masterSlider.onValueChanged.AddListener(SetMasterVolume);
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _soundSlider.onValueChanged.AddListener(SetSoundVolume);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseControl.Instance.GameIsPaused)
            {
                PauseControl.Instance.ResumeGame();
                _settingsCanvas.enabled = false;
            }
            else
            {
                PauseControl.Instance.PauseGame();
                _settingsCanvas.enabled = true;
            }
        }
    }

    private void SetMasterVolume(float value)
    {
        AudioManager.Instance.MasterVolume = value;
    }

    private void SetMusicVolume(float value)
    {
        AudioManager.Instance.MusicVolume = value;
    }

    private void SetSoundVolume(float value)
    {
        AudioManager.Instance.SoundVolume = value;
    }

    public void ResumeGameButton()
    {
        PauseControl.Instance.ResumeGame();
        _settingsCanvas.enabled = false;
    }

    #endregion
}