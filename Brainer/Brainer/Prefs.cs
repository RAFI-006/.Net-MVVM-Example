using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer
{
    class Prefs
    {  
        // Set function to check weather data is downloaded or not
        public static void SaveCurrentState(string json, string Key)
        {
            if (App.Current.Properties.ContainsKey(Key))
            {
            
                App.Current.Properties[Key] = json;
             
            }
            else
                App.Current.Properties.Add(Key, json);
            App.Current.SavePropertiesAsync();
        }

        // Get function to check weather data is downloaded or not
        public static string GetCurrentState(string Key)
        {
            if (App.Current.Properties.ContainsKey(Key))
            {
                string s = (string)App.Current.Properties[Key];
                return s;

            }
            else
                return null;
        }

        // Set Fun to store IntroScreen state so that it appear only once
        public static void SetIntroBool(bool value,string Key)
        {
            if (App.Current.Properties.ContainsKey(Key))
            {
        
                App.Current.Properties[Key] = value;
              
            }
            else
                App.Current.Properties.Add(Key, value);
                App.Current.SavePropertiesAsync();

        }
        //Get Fun to store IntroScreen state so that it appear only once

        public static bool GetIntroBool(string key)
        {
            if (App.Current.Properties.ContainsKey(key))
            {
                bool value = (bool)App.Current.Properties[key];
                return value;
            }
            else
                return false;

        }

    }
}
    
