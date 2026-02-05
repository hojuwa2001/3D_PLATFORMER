using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("ÆÛÁñ")]
    public TargetSlot[] TargetSlots;
    public Material PuzzleFinishMat;

    private MeshRenderer MeshRenderer;
    private bool isTriggered;
    private bool canFinished;

    private void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    private void CanGoal()
    {
        if (canFinished) return;
        canFinished = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Plyaer") && !isTriggered && canFinished)
        {
            Debug.Log("¿ì½Â");
            isTriggered = true;
        }
    }
}
