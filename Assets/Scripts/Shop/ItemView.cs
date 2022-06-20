using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;


    [SerializeField] private string _saveName;
    private CustomBall _ball;

    public event UnityAction<CustomBall, ItemView> SellButtonClick;


    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(Buyed);

    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(Buyed);

    }

    private void Buyed() 
    {
        if (_ball.IsBuyed)
        {
            _price.text = "Куплено";
        }
    }


    public void Render(CustomBall customBall)
    {
        _ball = customBall;

        customBall.Starter();

        _label.text = customBall.Label;
        if (_ball.IsBuyed)
            _price.text = "Куплено";
        else
        _price.text = customBall.Price.ToString();

        
        _icon.sprite = customBall.Icon;

    }


    private void OnButtonClick() 
    {
        SellButtonClick?.Invoke(_ball, this);
    }
}
