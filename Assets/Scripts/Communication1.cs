using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using TMPro;

public class Communication1 : MonoBehaviour
{
    public GameObject hintPanel;
    public TextMeshProUGUI dialogueText;
    public GameObject CommunicationPanel;
    public GameObject Player;
    public Vector3 yOffset;
    public XRNode inputSource = XRNode.RightHand;
    private SentenceLibrary1 sentenceLibrary1;
    private List<string> dialogueList;
    public float letterDelay = 0.1f;
    private AudioSource audioSource;
    private bool isPlayerInRange;
    private bool isInteracting;
    private bool isDialogueInProgress;
    private int currentDialogueIndex;
    private List<string> randomSentences;
    private List<AudioClip> randomAudios;

    private void Start()
    {   
        audioSource = GetComponent<AudioSource>();
        sentenceLibrary1 = FindObjectOfType<SentenceLibrary1>();
        hintPanel.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            KeyValuePair<List<string>, List<AudioClip>> randomData = sentenceLibrary1.GenerateRandomSentences();
            randomSentences = randomData.Key;
            randomAudios = randomData.Value;
            isPlayerInRange = true;
            hintPanel.gameObject.SetActive(true);
            currentDialogueIndex = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            hintPanel.gameObject.SetActive(false);
            CommunicationPanel.SetActive(false);
            isInteracting = false;
        }
    }

    private void Update()
    {   
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        bool triggerValue;
        if (isPlayerInRange && device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {   
            if (!isInteracting)
            {
                isInteracting = true;

                if (currentDialogueIndex < randomSentences.Count)
                {   
                    audioSource.clip = randomAudios[currentDialogueIndex];
                    audioSource.Play();
                    CommunicationPanel.SetActive(true);
                    StartCoroutine(ShowDialogue());
                }
                else
                {
                    CommunicationPanel.SetActive(false);
                    currentDialogueIndex = 0;
                    Player.transform.SetParent(null);
                }
            }
        }
    }

    IEnumerator ShowDialogue()
    {
        isDialogueInProgress = true;
        string dialogueContent = randomSentences[currentDialogueIndex];
        dialogueText.text = "";

        for (int i = 0; i < dialogueContent.Length; i++)
        {
            dialogueText.text += dialogueContent[i];
            yield return new WaitForSeconds(letterDelay);
        }
        isInteracting = false;
        currentDialogueIndex++;
        isDialogueInProgress = false;
    }
}



