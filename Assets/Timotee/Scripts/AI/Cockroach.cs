using System.Collections.Generic;
using UnityEngine;

public class Cockroach : MonoBehaviour{
    public static List<Cockroach> Alive = new();
    public Vector3 Position => transform.position;

    private void Start(){
        Alive.Add(this);
    }

    private void OnDestroy(){
        Alive.Remove(this);
    }
}