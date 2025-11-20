using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    [SerializeField] private string _name;
    [SerializeField] private DAMAGE_TYPE _dmgType;
    [SerializeField] private ELEMENT _elem;
    [SerializeField] private Stats _bonusStats;

    public Weapon(string name, DAMAGE_TYPE dmgType, ELEMENT elem, Stats bonusStats)
    {
        SetName(name);
        SetDmgType(dmgType);
        SetElem(elem);
        SetBonusStats(bonusStats);
    }

    public string GetName() => _name;
    public void SetName(string name)
    {
        if (String.IsNullOrEmpty(name) == true || string.IsNullOrWhiteSpace(name) == true)
        {
            _name = "???";
        }
        else
        {
            _name = name;
        }
    }

    public DAMAGE_TYPE GetDmgType() => _dmgType;
    public void SetDmgType(DAMAGE_TYPE dmgType)
    {
        _dmgType = dmgType;
    }

    public ELEMENT GetElem() => _elem;
    public void SetElem(ELEMENT elem)
    {
        _elem = elem;
    }

    public Stats GetBonusStats() => _bonusStats;
    public void SetBonusStats(Stats bonusStats)
    {
        _bonusStats = bonusStats;
    }

}
