using System.Collections.Generic;
using JuicyDI.Attributes;
using JuicyDI.Demo.Scripts.Interfaces;
using UnityEngine;

namespace JuicyDI.Demo.Scripts
{
    [JDIMonoController]
    public class Test3JDIMonoController: MonoBehaviour, ITest3JDIMonoInterface, ITestStarter
    {
        [Inject] private List<ITest2JDIMonoInterface> m_Test1JDIMonoController;
        
        public void Run()
        {
            foreach (var test in m_Test1JDIMonoController)
            {
                Debug.Log($"ITest2JDIMonoInterface - {test == null}");
                test.Test2();
            } 
        }

        public void Test1()
        {
            Debug.Log($"Test3JDIMonoController - I exist");
        }
    }
}