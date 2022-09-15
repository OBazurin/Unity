using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float reloadTimeout = 2f; 
    [SerializeField] ParticleSystem fihishEffect;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            fihishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke(nameof(ReloadScene), reloadTimeout);
        }
    }

    void ReloadScene()
   {
        SceneManager.LoadScene(0);    
   }
}
