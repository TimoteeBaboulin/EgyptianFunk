using System;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour{
    public static List<Scorpion> Alive = new();
    public Vector3 Position => transform.position;

    private void Start(){
        Alive.Add(this);
    }

    private void OnDestroy(){
        Alive.Remove(this);
    }
}