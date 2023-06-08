using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationWithCSharp.Utilities
{
    public class JsonReader
    {


        public JsonReader() { }

        
        public String ExtractData(String tokenName)
        {
            String myJsonstring=File.ReadAllText("C:\\Selenium Projects\\SeleniumAutomationWithCSharp\\TestData.json");
            var jsonObject=JToken.Parse(myJsonstring);
           return jsonObject.SelectToken(tokenName).Value<String>();
        }

        public String[] ExtractDataArray(String tokenName)
        {
            String myJsonstring = File.ReadAllText("C:\\Selenium Projects\\SeleniumAutomationWithCSharp\\TestData.json");
            var jsonObject = JToken.Parse(myJsonstring);
            return jsonObject.SelectTokens(tokenName).Values<String>().ToList().ToArray();
        }

    }
}
