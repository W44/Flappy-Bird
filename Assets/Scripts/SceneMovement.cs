using UnityEngine;

public class SceneMovement: MonoBehaviour
{

    private MeshRenderer meshRenderer;
    public float movementSpeed = 0.5f;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(movementSpeed * Time.deltaTime, 0);
    }
}
