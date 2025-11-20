using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero
{
    [SerializeField] private string _name;
    [SerializeField] private int _hp;
    [SerializeField] private Stats _baseStats;
    [SerializeField] private ELEMENT _resistance;
    [SerializeField] private ELEMENT _weakness;
    [SerializeField] private Weapon _weapon;

    public Hero(string name, int hp, Stats baseStats, ELEMENT resistance, ELEMENT weakness, Weapon weapon)
    {
        SetName(name);
        SetHp(hp);
        SetBaseStats(baseStats);
        SetResistance(resistance);
        SetWeakness(weakness);
        SetWeapon(weapon);
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

    public int GetHp() => _hp;
    public void SetHp(int hp)
    {
        _hp = Mathf.Max(0, hp);
    }

    public Stats GetBaseStats() => _baseStats;
    public void SetBaseStats(Stats baseStats)
    {
        _baseStats = baseStats;
    }

    public ELEMENT GetResistance() => _resistance;
    public void SetResistance(ELEMENT resistance)
    {
        _resistance = resistance;
    }

    public ELEMENT GetWeakness() => _weakness;
    public void SetWeakness(ELEMENT weakness)
    {
        _weakness = weakness;
    }

    public Weapon GetWeapon() => _weapon;
    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void AddHp(int amount)
    {
        SetHp(_hp + amount);
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }

    public bool IsAlive()
    {
        if (_hp > 0)
        {
            return true;
        }
        return false;
    }
}
