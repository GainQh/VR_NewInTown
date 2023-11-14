using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public float stride = 0.5f; // 步长，即多久播放一次脚步声音
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
        // 检测是否发生位移
        if (characterController.velocity.magnitude > 0)
        {
            // 更新计时器
            stepTimer += Time.deltaTime;

            // 播放脚步声音
            if (stepTimer >= stride)
            {
                PlayFootstepSound();
                stepTimer = 0f; // 重置计时器
            }
        }
    }

    private void PlayFootstepSound()
    {
        // 从音频剪辑数组中随机选择一个音频剪辑
        AudioClip footstepClip = footstepSounds[Random.Range(0, footstepSounds.Length)];

        // 播放音频剪辑
        audioSource.PlayOneShot(footstepClip);
    }
}
