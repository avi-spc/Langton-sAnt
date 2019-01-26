using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{
    public int numberOfStates;

    public GameObject stateCombo, ant;

    public GameObject[] stateCombos;

    [SerializeField]
    public struct stateCombination {
        public string color;
        public string direction;
    }

    public Button enableCollider;

    public stateCombination[] states;

    public Dropdown directionDropdown, colorDropdown;

    public Text steps;

    public InputField numOfStates;

    public Color[] colorArray;
    public string[] directionArray;

    private void Awake() {       

    }

    void Start() {
        ant = GameObject.FindGameObjectWithTag("Ant");
        enableCollider.onClick.AddListener(ant.GetComponent<AntMovement>().EnableCollider);
    }

    private void Update() {
        steps.text = ant.GetComponent<AntMovement>().steps.ToString();
    }

    public void SetConfig() {
        for (int i = 0; i < stateCombos.Length; i++) {
            directionDropdown = stateCombos[i].GetComponentsInChildren<Dropdown>()[0];
            colorDropdown = stateCombos[i].GetComponentsInChildren<Dropdown>()[1];
            states[i].direction = directionDropdown.options[directionDropdown.value].text;
            states[i].color = colorDropdown.options[colorDropdown.value].text;
        }
        Debug.Log(states.Length);

        ant.GetComponent<AntMovement>().colors = SetColorArray();
        ant.GetComponent<AntMovement>().directions = SetDirectionArray();

    }

    public void InitialSetup() {
        numberOfStates = int.Parse(numOfStates.text);
        stateCombos = new GameObject[numberOfStates];
        for (int i = 0; i < stateCombos.Length; i++)
        {
            stateCombos[i] = Instantiate(stateCombo, transform.position, Quaternion.identity);
            stateCombos[i].transform.SetParent(GameObject.FindGameObjectWithTag("StateHolder").transform);
        }
        states = new stateCombination[stateCombos.Length];
        colorArray = new Color[stateCombos.Length];
        directionArray = new string[stateCombos.Length];
    }

    public Color[] SetColorArray() {
        for (int i = 0; i < stateCombos.Length; i++) {
            switch (states[i].color) {
                case "White" :
                    colorArray[i] = Color.white;
                    break;
                case "Red":
                    colorArray[i] = Color.red;
                    break;
                case "Green":
                    colorArray[i] = Color.green;
                    break;
                default:
                    break;
            }        
        }
        return colorArray;
    }

    public string[] SetDirectionArray() {
        for (int i = 0; i < states.Length; i++) {
            switch (states[i].direction) {
                case "Left":
                    directionArray[i] = "Left";
                    break;
                case "Right":
                    directionArray[i] = "Right";
                    break;
                default:
                    break;
            }
        }
        return directionArray;
    }
}
