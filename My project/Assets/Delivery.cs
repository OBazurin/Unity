using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] Color32 hasPackageColor = new Color32(255, 1, 1, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 1, 255);
    [SerializeField] float testroyTimeout = 0.5f;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
          spriteRenderer =  GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Looks like {this.name} just hit {other.collider.name}");
        Debug.LogError("You destroyed your car, sucker!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasPackage && other.tag == "Package")
        {
            Debug.Log("Picked!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, testroyTimeout);
        }
        if (hasPackage && other.tag == "Customer")
        {
            Debug.Log("Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
