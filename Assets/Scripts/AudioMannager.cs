using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // 싱글톤패턴 == GameManager, 씬 안에서 유일하게 존재하는 객체. 전역적(어디에서나 가져올 수 있음)인 접근점이 제공된다. 씬이동간에 사라지지않는다.
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}