using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Ball", menuName = "Balls")]
public class CustomBall : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;
    [SerializeField] private GameObject _ball;
    [SerializeField] private int _id;

    public string Label => _label;
    public int Price => _price;
    public  int Id => _id;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;

    public GameObject Ball => _ball;

    public void Buy() 
    {
        _isBuyed = true;
    }
}
