using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class UiVisualise : MonoBehaviour
{
    [SerializeField] private TMP_Text _finishMessage;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _bestTimeNumber;
    [SerializeField] private Slider _forceOfSlider;
    [SerializeField] private float _timer;
    [SerializeField] private Ball _ball;

    [SerializeField] private bool check;

    private int _time;
    private void Start()
    {
        if (check)
        {
            PlayerPrefs.SetInt("BestTime", 0);
        }
        _bestTimeNumber.text = PlayerPrefs.GetInt("BestTime").ToString();
        _timerText.text = _timer.ToString();
    }

    private void Update()
    {
        if (_ball.Started)
            CountTime();

        ShowForce(_ball.JumpForce);
    }

    private void OnEnable()
    {
        _ball.Finished += ShowFinish;
    }

    private void OnDisable()
    {
        _ball.Finished -= ShowFinish;
    }

    public void CountTime()
    {
        _timer -= Time.deltaTime;

       _time = (int)Mathf.Round(_timer);
        _timerText.text = _time.ToString();

        if (_timer <= 0)
        {
            _finishMessage.gameObject.transform.parent.gameObject.SetActive(true);
            _finishMessage.color = Color.red;
            _finishMessage.text = "Вы проиграли";
            Time.timeScale = 0;
            _timerText.text = "0";
        }

 
    }

    public void ShowForce(float ForceOfSlider)
    {

        _forceOfSlider.value = ForceOfSlider;

    }

    private void ShowFinish()
    {

            if (_timer > 0 && _time > PlayerPrefs.GetInt("BestTime"))
            PlayerPrefs.SetInt("BestTime", _time);
        _finishMessage.gameObject.transform.parent.gameObject.SetActive(true);
        
        
    }

}
