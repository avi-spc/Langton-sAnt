using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{
    public int numberOfColors;

    public GameObject stateCombo;

    public GameObject[] stateCombos;

    [SerializeField]
    public struct stateCombination {
        public string color;
        public string direction;
    }

    public stateCombination[] states;

    public Dropdown directionDropdown, colorDropdown;

    private void Awake() {
        stateCombos = new GameObject[numberOfColors];
        for (int i = 0; i < stateCombos.Length; i++) {
            stateCombos[i] = Instantiate(stateCombo, transform.position, Quaternion.identity);
            stateCombos[i].transform.SetParent(GameObject.FindGameObjectWithTag("StateHolder").transform);
        }
        states = new stateCombination[stateCombos.Length];
    }

    public void SetConfig() {
        for (int i = 0; i < stateCombos.Length; i++) {
            directionDropdown = stateCombos[i].GetComponentsInChildren<Dropdown>()[0];
            colorDropdown = stateCombos[i].GetComponentsInChildren<Dropdown>()[1];
            states[i].direction = directionDropdown.options[directionDropdown.value].text;
            states[i].color = colorDropdown.options[colorDropdown.value].text;
        }

        for (int i = 0; i < stateCombos.Length; i++)
        {
            Debug.Log(states[i].direction + states[i].color);
        }
        //states[0].color = colorDropdown.options[0].text;
        //states[0].direction = directionDropdown.options[0].text;
        //Debug.Log(states[0].color);
    }
}
