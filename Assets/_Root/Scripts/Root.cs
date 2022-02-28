using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snake3D.Map;

namespace Snake3D
{
    internal class Root : MonoBehaviour
    {

        private MainModel mainModel;
        private MainController mainController;


        // Start is called before the first frame update
        void Start()
        {
            new MapController(); 
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}