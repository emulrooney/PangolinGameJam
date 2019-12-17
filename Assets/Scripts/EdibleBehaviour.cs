using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleBehaviour : MonoBehaviour
{
    public int pointValue;

    public int Eat()
    {
        Destroy(this.gameObject);
        return pointValue;
    }
}