using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.0f;
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip failedSound;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem failedParticle;
    [SerializeField] ParticleSystem thrusterParticle;

    AudioSource _audioSource;
    
    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        DubugControls();
    }

    void DubugControls()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning || collisionDisabled) { return; }

        switch(collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;

        }

    }
    void StartSuccessSequence()
    {
        _audioSource.Stop();
        isTransitioning = true;
        _audioSource.PlayOneShot(successSound);
        successParticle.Play();
        GetComponent<MovementScript>().enabled = false;
        Invoke("LoadNextLevel", loadDelay);
    }
    void StartCrashSequence()
    {
        _audioSource.Stop();
        isTransitioning = true;
        _audioSource.PlayOneShot(failedSound);
        failedParticle.Play();
        GetComponent<MovementScript>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    
}
