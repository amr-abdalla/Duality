using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillFunctions 
{

    public static Dictionary<string, System.Action> skillActions = new Dictionary<string, System.Action>();

    static SkillFunctions()
    {
        skillActions.Add("NormalFire", NormalFire);
    }

    public static void InvokeSkill(string skillName)
    {
        skillActions[skillName].Invoke();
    }

    private static void NormalFire()
    {
        Debug.Log("Shoot Fire Projectile");
    }

}
