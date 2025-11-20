using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField] private Hero hero1;
    [SerializeField] private Hero hero2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hero1.IsAlive() == true && hero2.IsAlive() == true)
        {

        }
        else 
        {
            return;
        }
        
    }
}
