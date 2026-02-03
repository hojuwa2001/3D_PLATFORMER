using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("1. 기본 설정")]
    public float explosionDelay;
    public float explosionRadius;
    public float explosionForce;

    [Header("2. 폭발 경고 효과")]
    public Color WarningColor;
    public float BlinkSpeed;

    private float timer;
    private bool isActivated;
    private Renderer meshRenderer;
    private Color originColor;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {
        meshRenderer = GetComponent<Renderer>();
        originColor=meshRenderer.material.color;
    }

    void Update()
    {
        if(isActivated)
        {
            Blink();
        }

    }

    private void Activate()
    {
        isActivated = true;
    }

    private void Explode()
    {
        Debug.Log("폭발");
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in colliders)
        {
            PlayerMovement player = col.GetComponent<PlayerMovement>();
            if(player != null)
            {
                player.Respawn();
            }

        }
        Destroy(gameObject);
    }

    private void Blink()
    {
        timer += Time.deltaTime;
        meshRenderer.material.color = Color.Lerp(originColor, WarningColor, BlinkSpeed);
        float lerpValue = Mathf.PingPong(Time.time * BlinkSpeed, 1f);
        float speedMultiplier = 1f * (timer / explosionDelay) * 3f;

        if (timer >= explosionDelay)
        {
            Explode();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isActivated)
        {
            Activate();
        }
    }

    private void OnDrawGrizmoSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

    }
}


