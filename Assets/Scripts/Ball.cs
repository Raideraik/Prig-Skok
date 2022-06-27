using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _maxForce;
    [SerializeField] private float _speedOfFilling;
    [SerializeField] private float _timeOfFilling;
    [SerializeField] private UiVisualise _visual;
    [SerializeField] private ClickZone _clickZone;




    public float JumpForce { get; private set; }
    public bool Started { get; private set; }
    public int Score { get; private set; }
    public int Id { get; private set; }

    private AudioSource _audioSource;
    private LineRenderer _line;
    private Rigidbody _rigidbody;
    private bool _isReady = true;

    public event UnityAction Finished;
    public event UnityAction ScoreChanged;


    [Header("Color of Line")]
    [SerializeField] private Color _block;
    [SerializeField] private Color _segment;
    [SerializeField] private Color _finish;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _line = GetComponentInChildren<LineRenderer>();
        _audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1;

        _audioSource.loop = false;
        _audioSource.playOnAwake = false;
        
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
                AddScore(segment.GivePoints());
                _rigidbody.isKinematic = true;
                _rigidbody.velocity = Vector3.zero;
                _line.gameObject.SetActive(true);
                _isReady = true;

            }
            else if (hitInfo.collider.TryGetComponent(out Finish finish))
            {
                _line.SetColors(_finish, _finish);
                _line.gameObject.SetActive(true);

                Finished?.Invoke();

                Time.timeScale = 0;
            }
        }
    }

    public void AddSound(AudioClip audio) 
    {
        _audioSource.clip = audio;
    }

    public void AddScore(int points) 
    {
        Score = PlayerPrefs.GetInt("Score");
        Score += points;
        ScoreChanged?.Invoke();
        PlayerPrefs.SetInt("Score", Score);
    }

    public void TouchUp()
    {
        if (_isReady)
        {
            _audioSource.Play();
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
            Started = true;
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
    }
}
