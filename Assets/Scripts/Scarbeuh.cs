using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarbeuh : MonoBehaviour, IPrey
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 Position => transform.position;
}

public interface IPrey{
    public static List<IPrey> Preys;
    public Vector3 Position{ get; }
}
