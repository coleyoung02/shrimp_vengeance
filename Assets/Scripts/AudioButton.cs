using UnityEngine;

public class AudioButton : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference buttonSFX;

    public void playSoundClip()
    {
        FMODUnity.RuntimeManager.PlayOneShot(buttonSFX);
    }
}
