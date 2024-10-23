using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip soundToPlay; // The audio clip to play
    private AudioSource audioSource;

    private void Start()
    {
        // Get or add an AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundToPlay;
    }

    public void PlaySound()
    {
        if (audioSource != null && soundToPlay != null)
        {
            audioSource.PlayOneShot(soundToPlay);
        }
        else
        {
            Debug.LogWarning("AudioSource or soundToPlay is null.");
        }
    }
}
