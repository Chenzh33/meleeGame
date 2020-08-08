﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace meleeDemo {

    public class InputsDataPerFrame {
        public InputsDataPerFrame () {
            InputVector = new Vector2 ();
            KeysState = new bool[12];
        }
        public override string ToString () {
            string str = InputVector.ToString ();
            str += " ";
            for (int i = 0; i != 12; ++i) {
                if (KeysState[i])
                    str += "1";
                else
                    str += "0";
                if (i % 3 == 2)
                    str += " ";
            }
            return str;
        }
        public Vector2 InputVector;
        public bool[] KeysState;
        //public unsafe fixed bool KeysState[12];
        // = new bool[12];
    }

    public enum InputKeyType {
        KEY_MELEE_ATTACK,
        KEY_RANGE_ATTACK,
        KEY_DODGE,
        KEY_CHARGE
    }
    public enum InputKeyStateType {
        KEY_MELEE_ATTACK_DOWN,
        KEY_MELEE_ATTACK_UP,
        KEY_MELEE_ATTACK,
        KEY_RANGE_ATTACK_DOWN,
        KEY_RANGE_ATTACK_UP,
        KEY_RANGE_ATTACK,
        KEY_DODGE_DOWN,
        KEY_DODGE_UP,
        KEY_DODGE,
        KEY_CHARGE_DOWN,
        KEY_CHARGE_UP,
        KEY_CHARGE
    }
    public class VirtualInputManager : Singleton<VirtualInputManager> {

        public Dictionary<InputKeyType, KeyCode> DicKeys = new Dictionary<InputKeyType, KeyCode> ();
        public const int INPUT_BUFFER_SIZE = 16;
        private int curIndex = 0;
        private InputsDataPerFrame[] inputBuffer = new InputsDataPerFrame[INPUT_BUFFER_SIZE];

        public override void Init () {
            SetDefaultKeyConfig ();
            InitInputDataPool ();

        }

        private void InitInputDataPool () {
            for (int i = 0; i != INPUT_BUFFER_SIZE; ++i) {
                inputBuffer[i] = new InputsDataPerFrame ();
                //inputBuffer[i].InputVector = new Vector2();
                //inputBuffer[i].KeysState = new bool[12];
            }
        }

        public void SetDefaultKeyConfig () {
            DicKeys.Clear ();
            DicKeys.Add (InputKeyType.KEY_MELEE_ATTACK, KeyCode.I);
            DicKeys.Add (InputKeyType.KEY_RANGE_ATTACK, KeyCode.J);
            DicKeys.Add (InputKeyType.KEY_DODGE, KeyCode.K);
            DicKeys.Add (InputKeyType.KEY_CHARGE, KeyCode.L);

        }

        public int GetIndex () {
            return curIndex;
        }

        void Update () {

        }

        public InputsDataPerFrame GetTopInput () {
            return inputBuffer[curIndex];

        }
        public InputsDataPerFrame[] GetAllInputs () {
            return inputBuffer;
        }

        public void LoadInput (InputsDataPerFrame data) {
            curIndex = (curIndex + 1) % INPUT_BUFFER_SIZE;
            inputBuffer[curIndex].InputVector = data.InputVector;
            inputBuffer[curIndex].KeysState = (bool[]) data.KeysState.Clone ();
            //Debug.Log (inputBuffer[curIndex + 1].ToString());
            //Debug.Log (inputBuffer[curIndex + 1].KeysState[1]);
        }

    }
}