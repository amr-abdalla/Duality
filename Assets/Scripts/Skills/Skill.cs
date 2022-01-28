using UnityEngine;

[CreateAssetMenu(fileName = "Skill")]
public class Skill : ScriptableObject
{
    public new string name;
    public float coolDown = 0;
    public uint totalCharges = 1;

    private float lastUsedTime;
    private uint availableCharges;

    public void init(Skill skill)
    {
        this.name = skill.name;
        this.coolDown = skill.coolDown;
        this.totalCharges = skill.totalCharges;

        this.availableCharges = this.totalCharges;
        this.lastUsedTime = -this.coolDown;
    }

    public bool CanBeInvoked()
    {
        if (lastUsedTime + coolDown > Time.time)
        {
            return false;
        }

        return true;
    }

    public void ConsumeSkill()
    {
        if (availableCharges > 1)
        {
            availableCharges--;
            return;
        }

        availableCharges = totalCharges;
        lastUsedTime = Time.time;
    }

}
