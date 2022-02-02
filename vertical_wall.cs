using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertical_wall : MonoBehaviour
{
    Vector3 startingposition;
    [SerializeField] Vector3 movementvector;
    float movementfactor;
    [SerializeField ]float period = 2f;

    void Start()
    {
       startingposition = transform.position;
       Debug.Log(transform.position);   
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon)return;
        float cycles = (Time.time +1)/ period;
        const float tau  = Mathf.PI * 2;
        float rawsinwave = Mathf.Sin(cycles * tau);

        movementfactor = (rawsinwave + 1f)/2f;

        Vector3 offset = movementfactor * movementvector;
        transform.position = startingposition + offset;
    }
}