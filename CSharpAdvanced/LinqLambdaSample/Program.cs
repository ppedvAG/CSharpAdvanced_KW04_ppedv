using System;
using System.Collections.Generic;
using System.Linq; //mit System.Linq werden die Linq-Erweiterungsmethoden freigeschaltet

namespace LinqLambdaSample
{

    //LinqToSql -> OR-Mapper
    //Entity Frymework -> OR-Mapper (gewonnen und weiter supportet) 
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<Person> persons = new List<Person>()
            {
                new Person {Id=1, Age=37, Vorname="Kevin", Nachname="Winter"},
                new Person {Id=2, Age=29, Vorname="Hannes", Nachname="Preishuber"},
                new Person {Id=3, Age=19, Vorname="Scott", Nachname="Hunter"},

                new Person {Id=4, Age=21, Vorname="Scott", Nachname="Hanselmann"},
                new Person {Id=5, Age=45, Vorname="Daniel", Nachname="Roth"},
                new Person {Id=6, Age=50, Vorname="Bill", Nachname="Gates"},

                new Person {Id=7, Age=70, Vorname="Newton", Nachname="King"},
                new Person {Id=8, Age=40, Vorname="Andre", Nachname="R"},
                new Person {Id=9, Age=60, Vorname="Petra", Nachname="Musterfrau"},
            };

            //Was ist Linq und was ist Lambda 


            #region Beispiel 1 - Linq-Expresseion 

            IList<Person> personenBetween40And50 = (from p in persons
                                                    where p.Age >= 40 && p.Age <= 50
                                                    orderby p.Nachname
                                                    select p).ToList();

            //Linq-Functions + Lambda-Expressions
            IList<Person> personenBetween40And50B = persons.Where(p => p.Age >= 40 && p.Age <= 50)
                                                           .OrderBy(o => o.Nachname)
                                                           .ThenBy(o => o.Age)
                                                           .ToList();
            #endregion
            #region Calculation

            double altersdurschnittAller = persons.Average(a => a.Age);


            double AltersdurchschnittAlleMitarbeiterÜber40 = persons.Where(p=>p.Age > 40).Average(a => a.Age);


            int gesamtAlteR = persons.Sum(s => s.Age);
            #endregion

            #region ERmittlung einzelner Datensätze
            Person einePerson = personenBetween40And50B.First(); //Last() -> Gibt das erste oder letzte Element (Last()) aus der Liste zurück
            Person weiterePerson = personenBetween40And50B.FirstOrDefault(f=>f.Age == 133); //Default gibt null zurück

            Person onePerson = personenBetween40And50.Single(s => s.Id == 8);
            #endregion


            #region Verfügbarkeit

            //Count - Property stammt von IList/List 
            if (persons.Count > 0)
            {
                //Datensätze sind vorhanden
            }

            //Linq-Function Count() -> ermittelt
            if (persons.Count() > 0)
            {
                //Datensätze sind vorhanden
            }


            if (persons.Any(a=>a.Age > 100))
            {
                //Datensätze sind vorhanden
            }
            #endregion

            #region Paging
            int pagingNumber = 1; //Auf welcher Seite befinde ich mich -> [1] 2 3 
            int pagingSize = 3; //Anzahl der Elemente, die auf einer Seite angezeigt werden 


            //Skip(0) + Take (3)
            IList<Person> ersteSeite = persons.Skip((pagingNumber -1) * pagingSize).Take(pagingSize).ToList();


            //Skip(3) + Take (3)
            pagingNumber = 2;
            IList<Person> zweiteSeite = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();

            //Skip(6) + Take (3)
            pagingNumber = 3;
            IList<Person> dritteSeite = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();
            #endregion

        }
    }

    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
