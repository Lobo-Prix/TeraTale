﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerAccessorySlot : MonoBehaviour
{
    Image _image;

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    void OnEnable()
    {
        _image.sprite = Player.mine.accessory.sprite;
    }
}