using System.Collections.Generic;


public static class TemporaryDataClass{
    static Dictionary<string, string> dialogs = new Dictionary<string, string> {
        { "yorke", "벗아머크립" },
        { "hachi", "울어버렸다!" },
        { "onion", "왜 안와 ^^" }
    };

    static Dictionary<string, string> targets = new Dictionary<string, string> {
        { "money", "onion" },
        { "pocket", "chiikawa" },
    };

    public static string GetDialog(string name){
        if(dialogs.ContainsKey(name)){
            return dialogs[name];
        }

        return null;
    }

    public static string GetTarget(string name){
        if(targets.ContainsKey(name)){
            return targets[name];
        }

        return null;
    }
}