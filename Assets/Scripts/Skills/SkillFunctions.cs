using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillFunctions 
{

    public static Dictionary<string, System.Action<GameObject>> skillActions = new Dictionary<string, System.Action<GameObject>>();

    static SkillFunctions()
    {
        skillActions.Add("NormalFire", NormalFire);
        skillActions.Add("NormalWater", NormalWater);
    }

    public static void InvokeSkill(string skillName, GameObject instigator)
    {
        skillActions[skillName].Invoke(instigator);
    }

    private static void NormalFire(GameObject instigator)
    {
        var projectile = Resources.Load<GameObject>("RedProjectile");
        projectile.transform.position = instigator.transform.position + new Vector3(0, instigator.transform.lossyScale.y/2, instigator.transform.lossyScale.z/2) ;

        projectile.transform.forward = instigator.transform.forward;

        Object.Instantiate(projectile);
    }

    private static void NormalWater(GameObject instigator)
    {
        var projectile = Resources.Load<GameObject>("BlueProjectile");
        projectile.transform.position = instigator.transform.position + new Vector3(0, instigator.transform.lossyScale.y / 2, instigator.transform.lossyScale.z / 2);

        projectile.transform.forward = instigator.transform.forward;

        Object.Instantiate(projectile);
    }

}
