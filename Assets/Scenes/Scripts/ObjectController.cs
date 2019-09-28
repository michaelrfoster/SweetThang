//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google Inc.">
// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleVR.HelloVR
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    /// <summary>Controls interactable teleporting objects in the Demo scene.</summary>
    [RequireComponent(typeof(Collider))]
    public class ObjectController : MonoBehaviour
    {
        /// <summary>
        /// The material to use when this object is inactive (not being gazed at).
        /// </summary>
        public Material inactiveMaterial;

        /// <summary>The material to use when this object is active (gazed at).</summary>
        public Material gazedAtMaterial;

        public Text UIText;
        public string button;
        public static bool isLocked = false;

        private Vector3 startingPosition;
        private Renderer myRenderer;

        /// <summary>Sets this instance's GazedAt state.</summary>
        /// <param name="gazedAt">
        /// Value `true` if this object is being gazed at, `false` otherwise.
        /// </param>
        public void SetGazedAt(bool gazedAt)
        {
            if (inactiveMaterial != null && gazedAtMaterial != null)
            {
                myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
                return;
            }
        }

        /// <summary>Calls the Recenter event.</summary>
        public void Recenter()
        {
#if !UNITY_EDITOR
            GvrCardboardHelpers.Recenter();
#else
            if (GvrEditorEmulator.Instance != null)
            {
                GvrEditorEmulator.Instance.Recenter();
            }
#endif  // !UNITY_EDITOR
        }

        public void AddNumbers()
        {
            Debug.Log(isLocked);
            if (isLocked)
            {
                UIText.text = button;
                isLocked = false;
                return;
            }
            if (UIText.text.Equals("0"))
            {
                UIText.text = button;
            }
            else
            {
                UIText.text += button;
                
            }
           
        }

        public void AddOperations()
        {
            if (isLocked)
            {
                UIText.text = "0 " + button + " ";
                isLocked = false;
                return;
            }
            if (UIText.text[UIText.text.Length - 1] == ' ')
            {
                return;
                
            }
            Calculate();
            UIText.text += " " + button + " ";

        }

        public void ClearScreen()
        {
            UIText.text = "0";
        }

        public void Calculate()
        {
            string[] I = UIText.text.Split(' ');
            if (I[I.Length - 1] == "")
            {
                UIText.text = "INVALID INPUT";
                isLocked = true;
                return;
            }
            
            if (I.Length < 3)
            {
                return;
            }

            try
            {
                switch(I[1])
                {
                    case "+":
                        UIText.text = (int.Parse(I[0]) + int.Parse(I[2])).ToString(); break;
                    case "-":
                        UIText.text = (int.Parse(I[0]) - int.Parse(I[2])).ToString(); break;
                    case "x":
                        UIText.text = (int.Parse(I[0]) * int.Parse(I[2])).ToString(); break;
                    case "%":
                        UIText.text = (int.Parse(I[0]) / int.Parse(I[2])).ToString(); break;
                    default:

                        break;
                }
            }
            catch (System.DivideByZeroException)
            {
                UIText.text = "DIVIDE BY ZERO ERROR";
                isLocked = true;
            }

        }

        private void Start()
        {
            startingPosition = transform.localPosition;
            myRenderer = GetComponent<Renderer>();
            SetGazedAt(false);
        }
    }
}
