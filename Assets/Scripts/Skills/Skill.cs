using UnityEngine;

[CreateAssetMenu(fileName = "Skill")]
public class Skill : ScriptableObject
{
    public new string name;
    public float coolDown = 0;
    public uint totalCharges = 1;

    [HideInInspector]
    public float lastUsedTime;

    [HideInInspector]
    public uint availableCharges;

    private void Awake()
    {
        availableCharges = totalCharges;
        lastUsedTime = -coolDown;
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
