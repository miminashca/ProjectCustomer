using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{  
    public Transform handTransform; // Assign your hand model in the inspector
    public LineRenderer lineRenderer; // Assign a Line Renderer component in the inspector

    [SerializeField] private InputActionProperty gripAnim;

    private void Update()
    {
        float gripvalue = gripAnim.action.ReadValue<float>();
        Ray ray = new Ray(handTransform.position, handTransform.forward);
        RaycastHit hit;

        // Update the line renderer positions
        lineRenderer.SetPosition(0, handTransform.position);

        if (Physics.Raycast(ray, out hit))
        {
            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.CompareTag("Level"))
            {
                // Optionally highlight the level
                HighlightLevel(hit.collider.gameObject);

                // Check for selection input (e.g., trigger press)
                if (gripvalue > .8)
                {
                    LoadSelectedLevel();
                }
            }
        }
        else
        {
            // Extend the line if nothing is hit
            lineRenderer.SetPosition(1, ray.GetPoint(10));
        }
    }

    private void HighlightLevel(GameObject level)
    {
        // Example highlight logic (change color, etc.)
        Renderer renderer = level.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Change color to indicate selection
            renderer.material.color = Color.yellow;
        }
    }

    private void LoadSelectedLevel()
    {
        // Logic to load the chosen level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Assumes the level's name matches the scene name
    }
}
