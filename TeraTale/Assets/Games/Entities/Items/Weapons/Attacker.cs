﻿using UnityEngine;
using System.Collections;
using TeraTaleNet;

public class Attacker : MonoBehaviour
{
    public string targetTag;
    AliveEntity _owner;
    Collider _collider;
    TrailRenderer _trail;

    void Awake()
    {
        _owner = GetComponentInParent<AliveEntity>();
        _collider = GetComponent<Collider>();
        _trail = GetComponentInChildren<TrailRenderer>();
    }

    void OnTransformParentChanged()
    {
        _owner = GetComponentInParent<AliveEntity>();
    }

    void OnEnable()
    {
        if (_collider)
            _collider.enabled = true;
        if (_trail)
            _trail.enabled = true;
    }

    void OnDisable()
    {
        if (_collider)
            _collider.enabled = false;
        if (_trail)
            _trail.enabled = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (NetworkScript.isLocal)
            return;
        if (coll.tag == targetTag)
        {
            var ae = coll.GetComponent<AliveEntity>();
            ae.Damage(new Damage(Damage.Type.Physical, _owner.attackDamage, 0, false));
        }
    }
}