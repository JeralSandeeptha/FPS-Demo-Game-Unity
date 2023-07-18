using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private float _shootRange = 300f;
    [SerializeField] private ParticleSystem _muzzleFlashFX;
    [SerializeField] private GameObject _hitImpactFX;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            PlayerShoot();
            _muzzleFlashFX.Play();
        }
        else {
            _muzzleFlashFX.Stop();
        }
    }

    private void PlayerShoot() 
    {
        RaycastHit _hitinfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hitinfo, _shootRange))//this is a bool
        {
            print("I shoot " + _hitinfo.transform.name);
            //create hit impact
            CreateHitImpact(_hitinfo);
        }
        else {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hitinfo)
    {
        //instantiate partical system
        GameObject _hitImpactClone = Instantiate(_hitImpactFX, hitinfo.point, Quaternion.LookRotation(hitinfo.normal));
        //destroy that partical system
        Destroy(_hitImpactClone, 1f);
    }
}