using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// As Unity Coroutines do not return a value, this will run a coroutine function until it reaches the result value, and set it as the Value. 
/// </summary>
/// <typeparam name="T"></typeparam>
public class CoroutineReturn<T> where T : class
{

    /// <summary>
    /// The result value. 
    /// </summary>
    public T Value;

    public CoroutineReturn()
    {
        Value = default(T);
    }

    /// <summary>
    /// Starts the given coroutine. 
    /// </summary>
    /// <param name="coroutine"></param>
    /// <returns></returns>
    public IEnumerator Start(IEnumerator coroutine)
    {
        while (coroutine.MoveNext())
        {
            yield return coroutine.Current;
        }
        Value = coroutine.Current as T;
    }
}

