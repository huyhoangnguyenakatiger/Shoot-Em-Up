using UnityEngine;

namespace Shmup
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        AudioSource audioSource;
        [SerializeField] AudioClip background;
        [SerializeField] AudioClip singleShot;
        [SerializeField] AudioClip trackingShot;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                PlayBackground();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayBackground()
        {
            audioSource.clip = background;
            audioSource.Play();
        }
        public void PlaySingleShot() => audioSource.PlayOneShot(singleShot);
        public void PlayTrackingShot() => audioSource.PlayOneShot(trackingShot);

        public void ChangeMusic(AudioClip newClip)
        {
            if (audioSource != null)
            {
                audioSource.clip = newClip;
                audioSource.Play();
            }
        }
    }

}