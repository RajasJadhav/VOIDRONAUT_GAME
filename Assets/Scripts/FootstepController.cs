using UnityEngine;

public class FootstepController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClip;

    private float minPitch = 0.9f;
    private float maxPitch = 1.1f;
    public void PlayFootStep()
    {

        if (audioClip.Length == 0 || audioSource == null) return;

        int index = Random.Range(0, audioClip.Length);

        AudioClip clip = audioClip[index];

        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.PlayOneShot(clip); 
    }
}
