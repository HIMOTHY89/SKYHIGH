using UnityEngine;

public class DIFFICULTYMANAGER : MonoBehaviour
{
    public PipeMoveScript pipeMoveScript;  

    float basePipeSpeed = 100.0f;
    float speedIncrease = 100.0f;

    public void DIFFICULTY()
    {
        Time.timeScale = 0.0f;
        pipeMoveScript.moveSpeed = basePipeSpeed;
    }

    public void DIFFICULTY1()
    {
        Time.timeScale = 0.0f;
        pipeMoveScript.moveSpeed = basePipeSpeed + speedIncrease;
    }

    public void DIFFICULTY2()
    {
        Time.timeScale = 0.0f;
        pipeMoveScript.moveSpeed = basePipeSpeed + (speedIncrease * 2f);
    }
}
