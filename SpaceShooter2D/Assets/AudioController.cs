using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip shootSound;
    public AudioClip deathSound;
    public AudioClip hitSound;
    public AudioClip upgradeSound;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShootController.OnShoot += () => { audioSource.PlayOneShot(shootSound); };
        BulletBehavior.hit += () => { audioSource.PlayOneShot(hitSound); };
        Damageable.Death += () => { audioSource.PlayOneShot(deathSound); };
        TripleUpgrade.UpgradePickUp += () => { audioSource.PlayOneShot(upgradeSound); };

    }

    // Update is called once per frame
    void Update()
    {

    }


}
