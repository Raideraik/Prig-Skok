using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _maxForce;
    [SerializeField] private float _speedOfFilling;
    [SerializeField] private float _timeOfFilling;
    [SerializeField] private UiVisualise _visual;
    [SerializeField] private ClickZone _clickZone;

    public float JumpForce { get; private set; }
    private LineRenderer _line;
    private Rigidbody _rigidbody;
    private bool _isReady = true;
    private bool _doOnce = false;
    private bool _started = false;
    public bool Started => _started;

    public event UnityAction Finished;

    [Header("Color of Line")]
    [SerializeField]private Color _block;
    [SerializeField]private Color _segment;
    [SerializeField]private Color _finish;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _line = GetComponentInChildren<LineRenderer>();
        Time.timeScale = 1;
    }

    public void TouchDown()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent(out Block block))
            {
                _line.SetColors(_segment, _block);
                _line.gameObject.SetActive(true);
            }
            else if (hitInfo.collider.TryGetComponent(out Segment segment))
            {
                _line.SetColors(_segment, _segment);
                _rigidbody.isKinematic = true;
                _rigidbody.velocity = Vector3.zero;
                _line.gameObject.SetActive(true);
                _isReady = true;

            }
            else if (hitInfo.collider.TryGetComponent(out Finish finish))
            {
                _line.SetColors(_finish, _finish);
                _line.gameObject.SetActive(true);
                /* if (!_doOnce)
                 {
                     _visual.ShowFinish();
                     _doOnce = true;
                 }*/

                Finished?.Invoke();

                Time.timeScale = 0;
            }
        }
    }

    public void TouchUp() 
    {
        if (_isReady)
        {
            _timeOfFilling = 0.0f;
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

            _line.gameObject.SetActive(false);
            _isReady = false;
        }
    }


    private void Update()
    {
        

        
        if (Input.GetMouseButton(0))
        {
            _started = true;
           if (_isReady)
        {
            Ray ray = new Ray(transform.position, Vector3.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Segment segment))
                {
                    _timeOfFilling += Time.deltaTime * _speedOfFilling;
                    JumpForce = Mathf.PingPong(_timeOfFilling, _maxForce);
                }
            }
        }

        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            
        }*/

        /*
        if (Input.GetMouseButtonUp(0))
        {
            
        }*/
    }
}
