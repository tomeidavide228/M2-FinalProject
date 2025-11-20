using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Stats
{
    public int _atk;
    public int _def;
    public int _res;
    public int _spd;
    public int _crt;
    public int _aim;
    public int _eva;

    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {
        _atk = atk;
        _def = def;
        _res = res;
        _spd = spd;
        _crt = crt;
        _aim = aim;
        _eva = eva;
    }
    public static Stats Sum(Stats stats1, Stats stats2)
    {
        Stats statsResult = new Stats();

        statsResult._atk = stats1._atk + stats2._atk;
        statsResult._def = stats1._def + stats2._def;
        statsResult._res = stats1._res + stats2._res;
        statsResult._spd = stats1._spd + stats2._spd;
        statsResult._crt = stats1._crt + stats2._crt;
        statsResult._aim = stats1._aim + stats2._aim;
        statsResult._eva = stats1._eva + stats2._eva;

        return statsResult;
    }
}
