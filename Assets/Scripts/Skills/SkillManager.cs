using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public List<Skill> skills;
    private List<Skill> skillCopies = new List<Skill>(); //the list that's actually being used

    private void Awake()
    {
        foreach (Skill skill in skills)
        {
            Skill skillCopy = ScriptableObject.CreateInstance<Skill>();
            skillCopy.init(skill);
            skillCopies.Add(skillCopy);
        }
    }

    public void TryInvokeSkill(int index)
    {
        TryInvokeSkill(skillCopies[0]);
    }

    private void TryInvokeSkill(Skill skill)
    {
        if (skill.CanBeInvoked())
        {
            skill.ConsumeSkill();
            SkillFunctions.InvokeSkill(skill.name, gameObject);
        }
        else
        {
            Debug.Log("Skill on cooldown");
        }
    }
}
