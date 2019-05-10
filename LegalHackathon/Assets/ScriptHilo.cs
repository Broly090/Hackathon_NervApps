using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHilo : MonoBehaviour
{
    string nameHilo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DameDatitosHilo(string nombrehilo)
    {
        this.name = nombrehilo;
        nameHilo = nombrehilo.Substring(0,nombrehilo.Length-1);

    }
}
