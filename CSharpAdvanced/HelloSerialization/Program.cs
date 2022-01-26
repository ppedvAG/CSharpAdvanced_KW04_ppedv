using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HelloSerialization.Helper;
using Newtonsoft.Json;

namespace HelloSerialization
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Person person = new Person()
            {
                Vorname = "Max",
                Nachname = "Moritz",
                Alter = 19,
                Kontostand = 5_000,
                KreditLitmit = 50_000
            };

            Stream stream = null;

            
            #region Binär

            //Schreiben einer Klasse in eine Binary - Datei 
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            stream = File.OpenWrite("Person.bin");
            binaryFormatter.Serialize(stream, person);
            stream.Close();

            //Einlesen einer Binary - Datei 
            ////Lesen
            stream = File.OpenRead("Person.bin");
            Person geladenePerson = (Person)binaryFormatter.Deserialize(stream);
            stream.Close();
            #endregion

            #region XML
            //Object -> XML
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            stream = File.OpenWrite("Person.xml");
            xmlSerializer.Serialize(stream, person);
            stream.Close();

            //XML -> Object
            stream = File.OpenRead("Person.xml");
            Person geladenePerson2 = (Person)xmlSerializer.Deserialize(stream);
            stream.Close();
            #endregion

            #region JSON 
            //Schreiben
            string jsonString = JsonConvert.SerializeObject(person);
            await File.WriteAllTextAsync("Person.json", jsonString);

            //Lesen
            string readedJsonString = await File.ReadAllTextAsync("Person.json");
            Person geleadenePerson2 = JsonConvert.DeserializeObject<Person>(readedJsonString);
            #endregion


            #region CSVParser mit Erweiterungmethode
            person.Speichern("Person.csv");


            Person person2 = new Person();
            person2.Laden("Person.csv");
            #endregion
        }
    }

    [Serializable]
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }


        [field: NonSerialized] //beu Properties
        [XmlIgnore]
        [JsonIgnore]
        public decimal Kontostand { get; set; }

        //[NonSerialized] //bei einfachen Variablen
        [field: NonSerialized]
        [XmlIgnore]
        [JsonIgnore]
        public decimal KreditLitmit; 
    }
}
