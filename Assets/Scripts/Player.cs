using UnityEngine;

public class Player: MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    [SerializeField] private AudioSource flap;


    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f,0.15f);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            flap.Play();
            direction = Vector3.up * strength;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void AnimateSprite()
    {
        spriteRenderer.sprite = sprites[spriteIndex];
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
            FindObjectOfType<GameManager>().GameOver();
        else if (collision.gameObject.tag == "Score")
            FindObjectOfType<GameManager>().IncreaseScore();

    }
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        direction = Vector3.zero;
    }
}
