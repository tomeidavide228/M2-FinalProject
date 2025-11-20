using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GameFormulas
{
    public static bool HasElementAdvantage(ELEMENT attackElement, Hero defender)
    {

        if (attackElement == defender.GetWeakness())
        {
            return true;
        }
        return false;
    }

    public static bool HasElementDisadvantage(ELEMENT attackElement, Hero defender)
    {

        if (attackElement == defender.GetResistance())
        {
            return true;
        }
        return false;
    }

    public static float EvaluateElementalModifier(ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender) == true)
        {
            return 1.5f;
        }
        else if (HasElementDisadvantage(attackElement, defender) == true)
        {
            return 0.5f;
        }
        return 1f;
    }

    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker._aim - defender._eva;
        int chance = Random.Range(0, 99);
        if (chance > hitChance)
        {
            Debug.Log("MISS");
            return false;
        }
        return true;
    }

    public static bool IsCrit(int critValue)
    {
        int chance = Random.Range(0, 99);
        if (chance < critValue)
        {
            Debug.Log("CRIT");
            return true;
        }
        return false;
    }
    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        Stats attackerStats = new Stats();
        Stats defenderStats = new Stats();
        int totDef;
        int damage;
        float multiplier;

        attackerStats = Stats.Sum(attacker.GetBaseStats(), attacker.GetWeapon().GetBonusStats());
        defenderStats = Stats.Sum(defender.GetBaseStats(), defender.GetWeapon().GetBonusStats());

        if (attacker.GetWeapon().GetDmgType() == DAMAGE_TYPE.PHYSICAL)
        {
            totDef = defenderStats._def;
        }
        else
        {
            totDef = defenderStats._res;
        }

        damage = attackerStats._atk;
        damage -= totDef;

        multiplier = EvaluateElementalModifier(attacker.GetWeapon().GetElem(), defender);
        damage = (int)(damage * multiplier);

        if (IsCrit(attackerStats._crt) == true)
        {
            damage *= 2;
        }

        if (damage < 0)
        {
            return 0;
        }
        return damage;
    }
}
