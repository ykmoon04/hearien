using System.Collections.Generic;
using UnityEngine;

/*
    임시입니다^^
    신경쓰지말아요
*/
public class DialogManager : MonoBehaviour
{
    Dictionary<string, string> dialogs = new Dictionary<string, string> {
        { "yorke", "벗아머크립" },
        { "hachi", "울어버렸다!" },
        { "onion", "왜 안와 ^^" }
    };

    public static DialogManager i;

    private void Awake() {
        if(i==null){
            i = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public string GetDialog(string name){
        if(dialogs.ContainsKey(name)){
            return dialogs[name];
        }

        return null;
    }

    
}
