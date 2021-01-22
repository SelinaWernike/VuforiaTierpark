using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using System.Data;
using System;

public class EventDBTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
        ClueDAO deleteClue = new ClueDAO();
        deleteClue.deleteAllData();
        deleteClue.close();

        AnimalDAO deleteAll = new AnimalDAO();
        deleteAll.deleteAllData();
        deleteAll.close();

        EnclosureDAO dAO = new EnclosureDAO();
        dAO.deleteAllData();
        dAO.close();

        EventDAO eventDAO = new EventDAO();
        eventDAO.deleteAllData();
        eventDAO.close();
        
        EnclosureDAO enclosureDB = new EnclosureDAO();
        Debug.Log("Created Enclosure DB");
        Enclosure test1 = new Enclosure(1,"Huftierweide", -0.0674, 0.041, 0);
        Enclosure test2E = new Enclosure(2, "Bärenfelsen", -0.0086, -0.0941, 0);
        Enclosure test3E = new Enclosure(3, "Affenhaus", -0.0417, 0.0666, 0);
        Enclosure test4B = new Enclosure(4, "Giraffenhaus", 0.0156, 0.0211, 0);
        Enclosure test5B = new Enclosure(5, "Regenwaldhaus", 0.0459, -0.0277, 0);
        Enclosure test6B = new Enclosure(6, "Pferdewiese", 0.0547, -0.0545, 0);
        Enclosure test7B = new Enclosure(7, "Zebrawise", 0.0471, -0.0033, 0);
        Enclosure test8B = new Enclosure(8, "Vari Wald", -0.0126, -0.0062, 0);
        Enclosure test9B = new Enclosure(9, "Tierparkschule", -0.0546, -0.0742, 0);
        Enclosure teste10B = new Enclosure(10, "Kamelwiese", -0.0246, -0.0296, 0);
        Enclosure teste11B = new Enclosure(11, "Himalaya", -0.0075, 0.0622, 0);

        enclosureDB.addData(test1);
        enclosureDB.addData(test2E);
        enclosureDB.addData(test3E);
        enclosureDB.addData(test4B);
        enclosureDB.addData(test5B);
        enclosureDB.addData(test6B);
        enclosureDB.addData(test7B);
        enclosureDB.addData(test8B);
        enclosureDB.addData(test9B);
        enclosureDB.addData(teste10B);
        enclosureDB.addData(teste11B);
        enclosureDB.close(); 

        AnimalDAO animalDB = new AnimalDAO();
        Animal test2 = new Animal(1,"Katta", "KattaMaterial", "Herkunft: Madagaskar \n " +
                                                                "Lebensraum: Madagaskar \n" +
                                                                "Nahrung: Blätter, Gräser,Früchte,Blüten \n" +
                                                                "Größe: 45 cm \n" +
                                                                "Brutzeit: 4-5 Monate \n" +
                                                                "Alter: über 30 Jahre",
                                    5, test1);
        Animal test2A = new Animal(2, "Waldbison", "WaldbisonMaterial", "Herkunft: Nordamerika: Kanada, Alaska \n" +
                                                                        "Nahrung: Gras, Kräuter, Blätter, Rinde \n" +
                                                                        "Gewicht: w-600kg, m-1t \n" +
                                                                        "Tragezeit: ca. 283 Tage \n" +
                                                                        "Alter: bis zu 23 Jahre",
                                    4, test9B);
        Animal test3A = new Animal(3, "Dschelada", "DscheladaMaterial", "Herkunft: Afrika, Äthiopien \n " +
                                                                        "Lebensraum: Hochland \n" +
                                                                        "Nahrung: Samen, Nüsse, Früchte, Blüten \n" +
                                                                        "Gewicht: 12 bis 13 kg \n" +
                                                                        "Tragzeit: 5-6 Monate \n" +
                                                                        "Alter: über 30 Jahre",
                                    6, test3E);
        Animal test4A = new Animal(4, "Eisbär", "EisbaerMaterial", "Herkunft: Arktis \n" +
                                                "Nahrung: Roben, Fische, Kleinsäuger, Beeren, Früchte \n" +
                                                "Größe: 2,50m Länge \n" +
                                                "Tragzeit: 8-9 Monate \n" +
                                                "Alter: ca. 30Jahre",
                                    2, test2E);
        Animal giraffe = new Animal(5, "Rothschild-Giraffe", "GiraffeMaterial","Herkunft: Afrika- Kenia, Uganda \n" +
                                                            "Lebensraum: Baum- und Buschsavannen \n" +
                                                            "Nahrung: Laub, frische Triebe \n" +
                                                            "Größe: w-4,50 m-5,80 \n" +
                                                            "Gewicht: w-1,2t m-1,8t \n" +
                                                            "Tragzeit: 15 Monate \n" +
                                                            "Alter: ca. 25 Jahre",
                                    6, test4B);
        Animal sumatra = new Animal(6, "Sumatra Tiger", "SumatraTigerMaterial", "Herkunft: Indonesische Insel Sumatar \n" +
                                                                                "Nahrung: Groß- und Kleinsäugetiere \n" +
                                                                                "Größe: Länge: 2,20 bis 2,70 \n" +
                                                                                "Gewicht: w-110kg m-140kg \n" +
                                                                                "Tragzeit: 100 Tage \n" +
                                                                                "Alter: ca. 15 Jahre", 3, test5B);

        Animal vikuja = new Animal(7, "Vikuja", "VikujaMaterial", "Herkunft: Südamerika: Argentinien, Bolivien,Chile, Peru \n" +
                                                                    "Nahrung: Gräser, Kräuter \n" +
                                                                    "Gewicht: ca. 60kg \n" +
                                                                    "Alter: 25 Jahre",
                                    9, test1);

        

        animalDB.addData(test2);
        animalDB.addData(test2A);
        animalDB.addData(test3A);
        animalDB.addData(test4A);
        animalDB.addData(giraffe);
        animalDB.addData(sumatra);
        animalDB.addData(vikuja);
        animalDB.close();

        ClueDAO clueDB = new ClueDAO();
        clueDB.addData(new Clue(1, test2, "Diese in Madagaskar lebende Art gehört zu der Familie der Lemuren."));
        clueDB.addData(new Clue(2, test2, "Diese Primaten sind tagaktive Allesfresser und hauptsächlich Bodenbewohner."));
        clueDB.addData(new Clue(3, test2, "Ihr Erkennungsmerkmal ist der schwarz-weiß gestreifte, buschige Schwanz."));
        clueDB.addData(new Clue(4, test2A, "Diese Wildrinder besitzen ein dickes Winterfell, für welches sie früher häufig gejagt wurden."));
        clueDB.addData(new Clue(5, test2A, "Diese Wildrinder besitzen ein dickes Winterfell, für welches sie früher häufig gejagt wurden."));
        clueDB.addData(new Clue(6, test2A, "Ihr lateinischer Name lautet Bison bison athabascae."));
        clueDB.addData(new Clue(7, test3A, "Dieser Primat lebt in äthiopischen Hochland und wiegt zwischen 12 und 30 kg."));
        clueDB.addData(new Clue(8, test3A, "Die Männchen besitzen einen Harem zwischen 6 und 10 Weibchen."));
        clueDB.addData(new Clue(9, test4A, "Eine gefährdete Art die in der Arktis beheimatet ist."));
        clueDB.addData(new Clue(10, test4A, "Maskottchen eines bekannten Berliner Eishockey Vereins"));
        clueDB.addData(new Clue(11, sumatra, "Diese Fleischfresser leben auf der indonesischen Insel Sumatra und haben durch ihre Herkunft auch ihren Namen bekommen."));
        clueDB.addData(new Clue(12, sumatra, "Ihr lateinischer Name ist Panthera tigris sumatrae."));
        clueDB.addData(new Clue( 13, sumatra, "Diese indonesische Katzenart ist eine der am stärksten vom aussterben bedrohten Tierart."));
        clueDB.addData(new Clue(14, vikuja, "Dieses Tier ist das kleinsete Neuweltkamel"));
        clueDB.addData(new Clue(15, vikuja, "Diese Art gehört zu den Paarhufern und besitzt, im Gegensatz zu anderen vertretern seiner Familie, keine Höcker"));
        clueDB.addData(new Clue(16, vikuja, "Die Wolle dieser Kamelart gehört zu den teuersten Wollarten "));
        clueDB.addData(new Clue(17, vikuja, "Ihr lateinischer Name lautet Vicugna vicugna"));

        clueDB.close();

        EventDAO edao = new EventDAO();
        edao.addData(new Event(1, "Eisbären-Talk", DateTime.Parse("11:00:00"), 0, -0.0086, -0.0941));
        edao.addData(new Event(2, "Giraffen", DateTime.Parse("12:30:00"), 0, 0.0156, 0.0211));
        edao.addData(new Event(3, "Pinguin-Talk", DateTime.Parse("14:30:00"),0, 0.0459, -0.0277));
        edao.addData(new Event(4, "Affenfütterung", DateTime.Parse("14:30:00"), 0, -0.0417, 0.0666));
        edao.close();





        EventDAO eventDAO2 = new EventDAO();
        System.Data.IDataReader reader = eventDAO2.getAllData();

        int fieldCount = reader.FieldCount;
        List<Event> myList = new List<Event>();
        while(reader.Read())
        {
            Event ev = new Event(reader[0].ToString(),
                                            reader[1].ToString(),
                                            reader[2].ToString(),
                                            reader[3].ToString(),
                                            reader[4].ToString(),
                                            reader[5].ToString());
            Debug.Log(ev);
            myList.Add(ev);
        }
        reader.Close();
        eventDAO2.close();

        EnclosureDAO enclosureDAO1 = new EnclosureDAO();
        System.Data.IDataReader reader1 = enclosureDAO1.getAllData();

        List<Enclosure> listEnclosure = new List<Enclosure>();
        while(reader1.Read())
        {
            Enclosure en = new Enclosure(reader1[0].ToString(),
                                        reader1[1].ToString(),
                                        reader1[2].ToString(),
                                        reader1[3].ToString(),
                                        reader1[4].ToString());
            Debug.Log(en);
            listEnclosure.Add(en);
        }
        reader1.Close();
        enclosureDAO1.close();

        AnimalDAO animalDAO1 = new AnimalDAO();
        System.Data.IDataReader reader2 = animalDAO1.getAllData();
        List<Animal> animalList = new List<Animal>();
        

        while(reader2.Read())
        {
            Animal a = new Animal(reader2[0].ToString(),
                                reader2[1].ToString(),
                                reader2[2].ToString(),
                                reader2[3].ToString(),
                                reader2[4].ToString()
                                );
            Debug.Log(a);
            animalList.Add(a);
            
        }
        reader2.Close();
        animalDAO1.close();

      
        ClueDAO clueDAO1 = new ClueDAO();
        System.Data.IDataReader reader3 = clueDAO1.getAllData();
        List<Clue> clueList = new List<Clue>();
        while (reader3.Read())
        {
            Clue c = new Clue(reader3[0].ToString(),
                                reader3[1].ToString()
                );

            Debug.Log(c);
            clueList.Add(c);
            
        }
        reader3.Close();
        clueDAO1.close();
        
    }

}
