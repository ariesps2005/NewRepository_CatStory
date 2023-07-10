using CatStory;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    private CinemachineVirtualCamera _camera;

    private PlayerController _player;

    [SerializeField]
    private GameObject _water;

    private void Awake()
    {
        _camera = FindObjectOfType<CinemachineVirtualCamera>();
        _player = FindObjectOfType<PlayerController>();
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() && _player != null)
        {
            _camera.Follow = _water.transform;
        }
    }




}
