using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public float stride = 0.5f; // ����������ò���һ�νŲ�����
    private float stepTimer = 0f;
    private AudioSource audioSource;
    private CharacterController characterController;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // ����Ƿ���λ��
        if (characterController.velocity.magnitude > 0)
        {
            // ���¼�ʱ��
            stepTimer += Time.deltaTime;

            // ���ŽŲ�����
            if (stepTimer >= stride)
            {
                PlayFootstepSound();
                stepTimer = 0f; // ���ü�ʱ��
            }
        }
    }

    private void PlayFootstepSound()
    {
        // ����Ƶ�������������ѡ��һ����Ƶ����
        AudioClip footstepClip = footstepSounds[Random.Range(0, footstepSounds.Length)];

        // ������Ƶ����
        audioSource.PlayOneShot(footstepClip);
    }
}
