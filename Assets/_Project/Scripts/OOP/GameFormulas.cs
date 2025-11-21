using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

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

        int totDef;
        int damage;
        float multiplier;

        if (attacker.GetWeapon().GetDmgType() == DAMAGE_TYPE.PHYSICAL)
        {
            totDef = StatsSum(defender)._def;
        }
        else
        {
            totDef = StatsSum(defender)._res;
        }

        damage = StatsSum(attacker)._atk;
        damage -= totDef;

        multiplier = EvaluateElementalModifier(attacker.GetWeapon().GetElem(), defender);
        damage = (int)(damage * multiplier);

        if (IsCrit(StatsSum(attacker)._crt) == true)
        {
            damage *= 2;
        }

        if (damage < 0)
        {
            return 0;
        }
        return damage;
    }

    public static Stats StatsSum(Hero hero) 
    {
        Stats stats;
        stats = Stats.Sum(hero.GetBaseStats(), hero.GetWeapon().GetBonusStats());
        return stats;
    }

    public static void Combat(Hero attacker, Hero defender)
    {
        int dmg;

        Debug.Log($"{attacker.GetName()} attacks, {defender.GetName()} prepares to defend itself.");
        if (HasHit(StatsSum(attacker), StatsSum(defender)))
        {
            if (HasElementAdvantage(attacker.GetWeapon().GetElem(), defender))
            {
                Debug.Log("WEAKNESS");
            }
            else if (HasElementDisadvantage(attacker.GetWeapon().GetElem(), defender))
            {
                Debug.Log("RESIST");
            }

            dmg = CalculateDamage(attacker, defender);
            Debug.Log($"{attacker.GetName()} hit {defender.GetName()}, dealing {dmg} damage.");
            defender.TakeDamage(dmg);
        }
        else
        {
            Debug.Log($"{attacker.GetName()} missed {defender.GetName()}");
        }
    }
}
