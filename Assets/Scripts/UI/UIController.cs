using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _usageText;
    [SerializeField] public Canvas _questCanvas;
    [SerializeField] private TextMeshProUGUI _questTitle;
    [SerializeField] private TextMeshProUGUI _questDescription;
    [SerializeField] private QuestGiver _questGiver;
    [SerializeField] private TextMeshProUGUI _questIsActive;
    [SerializeField] public TextMeshProUGUI _questCompletedText;
    [SerializeField] private TextMeshProUGUI _questProgressText;
    
    private Button _acceptQuestButton;
    

    private string _usageTextBase = "Press E to ";
    
    void Start()
    {
        _usageText.text = _usageTextBase;
        _usageText.enabled = false;
        _questCompletedText.enabled = false;
        _questProgressText.text = _questGiver.quest.ShowProgress();
        _questProgressText.enabled = false;

        SetAndHideQuestWindow();

    }

    private void Update()
    {
        SetIsActive();
        SetCompletedQuestWindow();
    }

    public void SetAndHideQuestWindow()
    {
        _acceptQuestButton = GameObject.Find("AcceptQuestButton").GetComponent<Button>();
        
        _questTitle.text = _questGiver.quest.Title;
        _questDescription.text = _questGiver.quest.Description;
        _questCanvas.gameObject.SetActive(false);
    }

    private void SetCompletedQuestWindow()
    {
        if (_questGiver.quest.QuestGoal.IsReached())
        {
            _questTitle.text = "";
            _questDescription.text = "Hmm... Well done friend. Here, your reward...";
        }
    }

    public void SetUsageText(string verb, Collider other)
    {
        _usageText.text += verb + other.gameObject.name;
        _usageText.enabled = true;
    }

    public void ResetUsageText()
    {
        _usageText.SetText(_usageTextBase);
        _usageText.enabled = false;
    }

    public void AcceptButtonClicked()
    {
        if (!_questGiver.quest.IsActive)
        {
            _questGiver.AcceptQuest();
            _acceptQuestButton.gameObject.SetActive(false);
        }
        else
        {
            _acceptQuestButton.gameObject.SetActive(false);
        }
    }

    private void SetIsActive()
    {
        if (_questGiver.quest.IsActive)
        {
            _questProgressText.text = _questGiver.quest.ShowProgress();
            _questProgressText.enabled = true;
        }
        
        _questIsActive.color = _questGiver.quest.IsActive
            ? Color.green
            : Color.red;
    }
}
