using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;
       
    [Header("Music Sources")]
    [SerializeField] private AudioSource sfxPrefab;
    [SerializeField] private AudioSource mainMusicSource;
    [SerializeField] private AudioClip mainMusicClip;
    
    [Header("Player SFX")]
    [SerializeField] private AudioClip playerJumpClip;
    [SerializeField] private AudioClip shootClip;

    [Header("World SFX")]
    [SerializeField] private AudioClip bloodClip;
    [SerializeField] private AudioClip meteorClip;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip flyingClip;
    
    
    [Header("Volume Settings")]
    [Range(0f, 1f)] public float masterVolume = 0.5f;
    [Range(0f, 1f)] public float musicVolume = 0.5f;
    [Range(0f, 1f)] public float sfxVolume = 0.5f;

    [Header("Internal")]
    [SerializeField] private int sfxPoolSize = 5;
    private List<AudioSource> sfxPool;
    private int nextSfxIndex = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeSFXManager();

        //Initializing SFX pool
        sfxPool = new List<AudioSource>();
        for (int i = 0; i < sfxPoolSize; i++)
        {
            AudioSource src = Instantiate(sfxPrefab, transform);
            src.playOnAwake = false;
            sfxPool.Add(src);
        }

        if(mainMusicSource != null)
        {
            mainMusicSource.loop = true;
            mainMusicSource.playOnAwake = false;
        }
    }

    public void PlaySoundFX(AudioClip audioClip, Transform spawnTransform)
    {
        if (audioClip == null) return;

        AudioSource src = sfxPool[nextSfxIndex];
        nextSfxIndex = (nextSfxIndex + 1) % sfxPool.Count;

        src.transform.position = spawnTransform.position;
        src.volume = sfxVolume * masterVolume;  // <-- global scaling
        src.PlayOneShot(audioClip);
    }

    //PlaySoundFX with Volume Damping | 2 = 50%, 4 = 25% etc.
    public void PlaySoundFX(AudioClip audioClip, Transform spawnTransform, float volumeDamping)
    {
        if (audioClip == null) return;

        AudioSource src = sfxPool[nextSfxIndex];
        nextSfxIndex = (nextSfxIndex + 1) % sfxPool.Count;

        src.transform.position = spawnTransform.position;
        src.volume = (sfxVolume * masterVolume) / volumeDamping;  // <-- global scaling
        src.PlayOneShot(audioClip);
    }

    public void PlayPlayerJumpSFX()
    {
       PlaySoundFX(playerJumpClip, transform);
    }

    public void PlayShootSFX() {
        PlaySoundFX(shootClip, transform);
    }

    public void PlayBloodSFX() {
        PlaySoundFX(bloodClip, transform);
    }

    public void PlayMeteorSFX() {
        PlaySoundFX(meteorClip, transform);
    }

    public void PlayCoinSFX() {
        PlaySoundFX(coinClip, transform);
    }

    public void FlyingSFX() {
        PlaySoundFX(flyingClip, transform);
    }

    public void PreloadMusic(AudioClip audioClip)
    {
        audioClip.LoadAudioData();
    }

     public void PlayMainMusic()
    {
        
        if (mainMusicSource == null || mainMusicClip == null)
        {
            Debug.LogWarning("[SoundFXManager] Missing music source or clip");
            return;
        }
        mainMusicSource.gameObject.SetActive(true);
        mainMusicSource.clip = mainMusicClip;
        mainMusicSource.volume = (musicVolume * masterVolume) * 0.5f; //added 0.5f because its always loud af
        mainMusicSource.loop = true;
        mainMusicSource.Play();
    }

    private IEnumerator CrossfadeMusic(AudioSource fromSource, AudioSource toSource, AudioClip newClip, float fadeDuration)
    {
        if (newClip == null) yield break;

        float timer = 0f;

        toSource.clip = newClip;
        toSource.volume = 0f;
        toSource.loop = true;
        toSource.Play();

        float startFromVolume = fromSource.volume;
        float targetVolume = masterVolume * musicVolume;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;

            //Fade out
            fromSource.volume = Mathf.Lerp(startFromVolume, 0f, t);

            //Fade in
            toSource.volume = Mathf.Lerp(0f, targetVolume, t);

            yield return null;
        }

        //Ensure the volume is correct
        fromSource.volume = 0f;
        fromSource.Stop();
        toSource.volume = targetVolume;
    }

     // VOLUME SETTINGS
        public void SetMasterVolume(float value)
    {
        masterVolume = value;
        ApplyMusicVolumes();
    }

    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        ApplyMusicVolumes();
    }

    public void SetSfxVolume(float value)
    {
        sfxVolume = value;
    }

    private void ApplyMusicVolumes() //if we want to add additional music throughout the game
    {
        float v = masterVolume * musicVolume;
        if (mainMusicSource != null) mainMusicSource.volume = v;
    }

      private void InitializeSFXManager()
    {
        //Audio Sources
        sfxPrefab = Resources.Load<AudioSource>("SoundFX/SFXPrefab");
        mainMusicSource = transform.Find("MainMusicSource").GetComponent<AudioSource>();
     
        //Music
        mainMusicClip = Resources.Load<AudioClip>("SoundFX/MainMusic");

        //Player
        playerJumpClip = Resources.Load<AudioClip>("SoundFX/PlayerJumpSFX");
       
        //World
        bloodClip = Resources.Load<AudioClip>("SoundFX/BloodSFX");
        meteorClip = Resources.Load<AudioClip>("SoundFX/MeteorSFX");
        coinClip = Resources.Load<AudioClip>("SoundFX/CoinSFX");
        flyingClip = Resources.Load<AudioClip>("SoundFX/FlyingSFX");
    }
}