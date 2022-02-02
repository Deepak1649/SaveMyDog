using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverr : MonoBehaviour
{

    [SerializeField] float mainthrust = 100f;
    [SerializeField] float rotationthrust = 50f;
    [SerializeField] AudioClip StartEngine;
    [SerializeField] ParticleSystem MainThrustParticles;
    [SerializeField] ParticleSystem LeftThrustParticles;
    [SerializeField] ParticleSystem RightThrustParticles;


    bool alive;
    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
  
     void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainthrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(StartEngine);
        }
        if (!MainThrustParticles.isPlaying)
        {
            MainThrustParticles.Play();
        }
    }
     void StopThrusting()
    {
        audioSource.Stop();
        MainThrustParticles.Stop();
    }

    void ProcessRotation()
    {
        Leftrotation();
        Rightrotation();
    }

     void Rightrotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationthrust);

            if (!LeftThrustParticles.isPlaying)
            {
                LeftThrustParticles.Play();
            }
        }
        else LeftThrustParticles.Stop();
    }

    void Leftrotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationthrust);
            if (!RightThrustParticles.isPlaying)
            {
                RightThrustParticles.Play();
            }
        }
        else RightThrustParticles.Stop();
    }

    void ApplyRotation(float rotatethisframe)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotatethisframe * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
