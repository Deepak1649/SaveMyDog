using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class CollisionHandler : MonoBehaviour


{
    bool alive = false;
    bool collisondisable = false;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] float leveloadelay = 2f;
    [SerializeField] ParticleSystem successparticles;
    [SerializeField] ParticleSystem crashparticles;
    AudioSource audioSource;

     void Start() {
        audioSource=GetComponent<AudioSource>();
    }

    void Update() 
    {
        respondtodebugkeys();
    }
    void respondtodebugkeys()
    {
        if (Input.GetKey(KeyCode.L))
        {
            loadnextlevel();
        }
        if (Input.GetKey(KeyCode.C))
        {
            collisondisable = !collisondisable;
        }
    }
    void OnCollisionEnter(Collision other) {
        if(alive)return;
        if(collisondisable)return;
        switch (other.gameObject.tag)
        {
           case "friendly":
           Debug.Log("This thing is friendly");
           break;

           case "Finish":
           startsequence();   
           break;
           
        //    case "fuel":
        //    Debug.Log("You've picked up fuel");
        //    break;
           
           
           default:
           crashsequence();
           break;

        }
    }


    void startsequence()
    {   alive = true;
        
        audioSource.Stop();
        successparticles.Play();
        GetComponent<moverr>().enabled = false;
        audioSource.PlayOneShot(success);
           Invoke("loadnextlevel",leveloadelay);     
           
    }

    void crashsequence()
    {   alive = true;
        
        audioSource.Stop();
        crashparticles.Play();
        GetComponent<moverr>().enabled = false;
        audioSource.PlayOneShot(crash);
           Invoke("Reloadlevel",leveloadelay); 
    }
    void Reloadlevel()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(CurrentSceneIndex);}


  void loadnextlevel(){
       int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
       int nextsceneIndex = CurrentSceneIndex + 1;
       if( CurrentSceneIndex +1 == SceneManager.sceneCountInBuildSettings)
       {
           nextsceneIndex = 0;
       }

       SceneManager.LoadScene(nextsceneIndex);
  }
}