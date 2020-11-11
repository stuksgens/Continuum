using Lasm.EbbnFlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lasm.EbbnFlow
{
    public class Flow
    {
        public MonoBehaviour behaviour;
        internal object returnedValue = (object)null;

        private Dictionary<string, object> variables = new Dictionary<string, object>();

        public Flow(params (string name, object value)[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                variables.Add(parameters[i].name, parameters[i].value);
            }
        }

        public object Get(string name) => variables[name];

        public void Set(string name, object value)
        {
            if (variables.ContainsKey(name))
            {
                variables[name] = value;
                return;
            }

            variables.Add(name, value);
        }

        public bool Has(string name)
        {
            return variables.ContainsKey(name);
        }

        public void StartCoroutine(MonoFunction function, MonoBehaviour behaviour)
        {
            this.behaviour = behaviour;
            behaviour.StartCoroutine(function.Run(this));
        }

        public IEnumerator Yield(MonoFunction function)
        {
            yield return function.Run(this);
        }

        public void Invoke(MonoFunction function)
        {
            function.Invoke(this);
        }
    }
}