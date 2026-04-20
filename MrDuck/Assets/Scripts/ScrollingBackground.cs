using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.2f;
    private Material targetMaterial;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null) targetMaterial = rend.material;

      
        transform.localPosition = new Vector3(0, 0, 50f);
        transform.localScale = new Vector3(0.25f, 0.25f, 1f);
    }

    void Update()
    {
        if (targetMaterial == null) return;

       
        float xOffset = Time.time * scrollSpeed;
        targetMaterial.SetTextureOffset("_MainTex", new Vector2(xOffset, 0));

    
        if (transform.parent != null)
        {
            
            transform.localPosition = new Vector3(0, 0, 50f);
            transform.rotation = Quaternion.identity;

            
            float pX = transform.parent.localScale.x;
            transform.localScale = new Vector3(Mathf.Sign(pX) * 0.25f, 0.25f, 1f);
        }
    }
}