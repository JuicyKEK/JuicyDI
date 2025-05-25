using JuicyDI.Attributes;
using JuicyDI.Demo.Scripts.Interfaces;
using UnityEngine;

namespace JuicyDI.Demo.Scripts
{
    [JDIMonoController]
    public class Test2JDIMonoController: MonoBehaviour, ITest2JDIMonoInterface, ITest3JDIMonoInterface, ITestStarter
    {
        [Inject] private ITest1JDIMonoInterface m_Test1JDIMonoController;
        
        public void Run()
        {
            Debug.Log($"ITest1JDIMonoInterface - {m_Test1JDIMonoController == null}");
            m_Test1JDIMonoController.Test3();
        }

        public void Test2()
        {
            Debug.Log($"Test2JDIMonoController - I exist");
        }
    }
}