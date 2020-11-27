using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace GAD375.Prototyper
{
    public class ObjectEnabler : MonoBehaviour
    {
        [System.Serializable]
        public class ObjectInfo : NamedData<GameObject>
        {
        }

        public ObjectInfo[] objects;

        public GameObject image;
        
        [YarnCommand("show")]
        public void EnableObject(string objname)
        {
            GameObject g;
            if (ObjectInfo.FindByName(objects, objname, out g))
            {
                g.SetActive(true);
            }
        }

        [YarnCommand("delayshow")]
        public void DelayEnable()
        {
            StartCoroutine(DelayShowRoutine());
        }

        [YarnCommand("hide")]
        public void DisableObject(string objname)
        {
            GameObject g;
            if (ObjectInfo.FindByName(objects, objname, out g))
            {
                g.SetActive(false);
            }
            else
            {
                Debug.LogErrorFormat("Can't find object named {0}", objname);
            }
        }

        IEnumerator DelayShowRoutine()
        {
            yield return new WaitForSeconds(2);
            image.SetActive(true);
        }
    }
}