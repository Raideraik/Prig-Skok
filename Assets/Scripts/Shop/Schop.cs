using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Schop : MonoBehaviour
{
    [SerializeField] private List<CustomBall> _items;
    [SerializeField] private ItemView _template;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private TMP_Text _scoreText;

    private bool far;

    [SerializeField]private int _score;

    private void Start()
    {
        _score = PlayerPrefs.GetInt("Score");
        _scoreText.text = _score.ToString();
        

        for (int i = 0; i < _items.Count; i++)
        {
            AddItem(_items[i]);
        }
    }

    private void AddItem(CustomBall ball) 
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(ball);

    }


    private void OnSellButtonClick(CustomBall ball, ItemView view) 
    {
        TrySellBall(ball, view);
    }

    private void TrySellBall(CustomBall ball, ItemView view)
    {
        if (!ball.IsBuyed)
        {
            if (ball.Price <= _score)
            {
                _score -= ball.Price;
                _scoreText.text = _score.ToString();
                PlayerPrefs.SetInt("Score", _score);
                ball.Buy();
                PlayerPrefs.SetInt("ChoosedBall", ball.Id);
                PlayerPrefs.SetInt(ball.SaveName, Convert.ToInt32(true));
                view.SellButtonClick -= OnSellButtonClick;
            }
        }
        else
        {
            
            PlayerPrefs.SetInt("ChoosedBall", ball.Id);
        }
    }
}
