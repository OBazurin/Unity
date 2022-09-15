using UnityEngine;

public class CoolBoardEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem snowboardEffect;


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            snowboardEffect.Stop();
        }
    }

     void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground")
        {
            snowboardEffect.Play();
        }
    }
}
