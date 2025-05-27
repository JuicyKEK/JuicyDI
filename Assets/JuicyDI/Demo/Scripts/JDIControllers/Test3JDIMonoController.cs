using System.Collections.Generic;
using JuicyDI.Attributes;
using JuicyDI.Demo.Scripts.Interfaces;
using UnityEngine;

namespace JuicyDI.Demo.Scripts
{
    [JDIMonoController]
    [SequenceParticipant(-1)]
    public class Test3JDIMonoController: MonoBehaviour, ITest3JDIMonoInterface, ISequence
    {
        [Inject] private List<ITest2JDIMonoInterface> m_Test1JDIMonoController;
        
        public void Run()
        {

        }

        public void Test1()
        {
            Debug.Log($"Test3JDIMonoController - I exist");
        }

        public void MethodStart()
        {
            Debug.Log($"______Test3JDIMonoController____");
            foreach (var test in m_Test1JDIMonoController)
            {
                Debug.Log($"ITest3JDIMonoInterface - {test == null}");
                test.Test2();
            } 
        }
    }
}