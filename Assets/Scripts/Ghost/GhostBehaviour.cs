using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class GhostBehaviour : MonoBehaviour
{
    [SerializeField] private SplineAnimate L_R_spline;
    [SerializeField] private SplineAnimate R_L_spline;
    private bool ghostRoutineStarted;
    private void Update()
    {
        if (!ghostRoutineStarted)
        {
            ghostRoutineStarted = true;
            StartCoroutine(GhostRoutine());
        }
    }
    private IEnumerator GhostRoutine()
    {
        while (true)
        {
            L_R_spline.Restart(true);
            yield return new WaitForSeconds(23.0f);
            R_L_spline.Restart(true);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
