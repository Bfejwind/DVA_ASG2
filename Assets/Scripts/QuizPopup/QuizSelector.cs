using UnityEngine;

public class QuizSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] puzzles;
    private GameObject currentQuiz;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject puzzle in puzzles)
        {
            puzzle.SetActive(false);
        }
    }
    public void SelectQuiz(string quizName)
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            if (puzzles[i].name == quizName)
            {
                puzzles[i].SetActive(true);
                currentQuiz = puzzles[i];
            }
        }
    }
    public void DeselectQuiz()
    {
        if (currentQuiz != null)
        {
            currentQuiz.SetActive(false);
        }
    }

    
}
