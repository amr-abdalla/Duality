using UnityEngine;

public class SkillController : MonoBehaviour
{
    private SkillManager skillManager;

    void Start()
    {
        skillManager = GetComponent<SkillManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            skillManager.TryInvokeSkill(0);
        }
    }
}
