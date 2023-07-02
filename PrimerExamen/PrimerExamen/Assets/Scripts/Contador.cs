using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Contador
{
    public int Puntos { get; private set; }

    public void Incrementar()
    {
        Puntos++;
    }

    public void Resetear()
    {
        Puntos = 0;
    }
}
