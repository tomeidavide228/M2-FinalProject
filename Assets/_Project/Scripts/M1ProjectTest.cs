using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField] private Hero hero1;
    [SerializeField] private Hero hero2;
    private Hero first;
    private Hero second;
    private int round = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hero1.IsAlive() == true && hero2.IsAlive() == true)
        {
            Debug.Log($"Round {round}\n{hero1.GetName()} HP: {hero1.GetHp()}    {hero2.GetName()} HP: {hero2.GetHp()}");


            if (GameFormulas.StatsSum(hero1)._spd > GameFormulas.StatsSum(hero2)._spd)
            {
                first = hero1;
                second = hero2;
            }
            else
            {
                first = hero2;
                second = hero1;
            }

            GameFormulas.Combat(first, second);

            if (second.IsAlive())
            {
                GameFormulas.Combat(second, first);
                round++;
            }
            else
            {
                Debug.Log($"{second.GetName()} is defeated, {first.GetName()} is the winner");
            }

            if (first.IsAlive() == false)   //This "if" is to check if First is still alive after Second's attack, since if First dies without this "if" the victory messages do not come out.
            {
                Debug.Log($"{first.GetName()} is defeated, {second.GetName()} is the winner");
            }
        }
        else
        {
            return;
        }

    }
}
