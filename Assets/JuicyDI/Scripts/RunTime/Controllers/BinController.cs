using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;
using System.Linq;
using Codice.LogWrapper;

namespace JuicyDI
{
    public class BinController : IBinController
    {
        private static IBinController m_CurrentContext;
        
        private List<Type> m_FastSearchNamespacesByClasses;
        private IObjectFactory m_ObjectFactory = new JDIObjectFactory();
        
        public BinController(List<Type> fastSearchNamespacesByClasses = null)
        {
            m_FastSearchNamespacesByClasses = fastSearchNamespacesByClasses;
            RegisterCurrentContext();
        }
        
        public static IBinController GetContext()
        {
            return m_CurrentContext;
        }
        
        public void InitBins(List<MonoBehaviour> monoBehaviours, bool isRegisterNonMonoBehavior = false)
        {
            RegisterCurrentContext();
            RemoveSceneContext();
            
            if (isRegisterNonMonoBehavior)
            {
                RegisterNonMonoBeans();
            }
            
            RegisterMonoBehaviorsBeans(monoBehaviours);
            InjectingBeans();
        }

        private void RemoveSceneContext()
        {
            m_ObjectFactory.RemoveSceneContext();
        }

        private void InjectingBeans()
        {
            m_ObjectFactory.InjectingBeans();
        }

        private void RegisterCurrentContext()
        {
            if (m_CurrentContext == null)
            {
                m_CurrentContext = this;
            }
        }
        
        private void RegisterMonoBehaviorsBeans(List<MonoBehaviour> monoBehaviours)
        {
            m_ObjectFactory.RegisterMonoBehaviorsBeans(monoBehaviours);
        }

        private void RegisterNonMonoBeans()
        {
            //ComingSoon
        }
    }
}