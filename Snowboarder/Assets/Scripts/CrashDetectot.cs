using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetectot : MonoBehaviour
{
    [SerializeField] private float reloadTimeout = 2f;
    [SerializeField] ParticleSystem dyingEffect;
    [SerializeField] AudioClip crashSfx;

    bool dead = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!dead && other.tag == "Ground")
        {
            dead = true;
            FindObjectOfType<PlayerController>().DisableControls();
            dyingEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSfx);
            Invoke(nameof(ReloadScene), reloadTimeout);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
