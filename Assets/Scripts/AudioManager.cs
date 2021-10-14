using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource audioSource;

	public AudioClip collectStar;

	public AudioClip pickUpToy;

	public AudioClip toyToMatcher;

	public AudioClip wonSound;

	public AudioClip gateSound;

	private void PlayAudioOneShot(AudioClip audioP)
	{
		audioSource.PlayOneShot(audioP);
	}

	public void PlayCollectStar()
	{
		PlayAudioOneShot(collectStar);
	}

	public void PlayPickUpToy()
	{
		PlayAudioOneShot(pickUpToy);
	}

	public void PlayToyToMatcher()
	{
		PlayAudioOneShot(toyToMatcher);
	}

	public void PlayWonSound()
	{
		PlayAudioOneShot(wonSound);
	}

	public void PlayGateSound()
	{
		PlayAudioOneShot(gateSound);
	}
}
