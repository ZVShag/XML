using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Console;
namespace SimpleProject
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        [NonSerialized]
        public string Ksys = "Dekart";
        public Point() { }
        public Point(int x,int y,int z)
        {
            this.x = x;
             this.y = y;
            this.z = z;
        }
        public override string ToString()
        {
            return $"Kor_x: {x}, Kor_y: {y}, Kor_z: {z},Kordinate system: {Ksys }.";
        }
    }
    public class cd
    {
        public string Artist { get;set; }
        public string Title { get;set; }
        public string Country { get;set; }
        public string Company { get;set; }  
        public double Price { get;set; }        
        public int Year { get;set; }
    
        public cd() { }
        public cd (string artist,string title,string country,string company, double price,
            int year)
        {
            this.Artist = artist;
            this.Title = title;
            this.Country = country;
            this.Company = company;
            this.Price = price;
            this.Year = year;
        }
        public override string ToString()
        {
            return $"Artist name {Artist}\n Album title {Title}\n Country {Country}\n Company {Company}\n Price cd {Price}\n Date {Year}";
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            cd p = new cd("Kobzon","Don","USSR","Kremlin",100.20,1990);
        
            XmlSerializer xmlFormat =new XmlSerializer(typeof(cd));
           
            try
            {
                using (Stream fStream =File.Create("test.xml"))
                {
                    xmlFormat.Serialize(fStream, p);
                }
                

                cd p2= null;
                using (Stream fStream =File.OpenRead("test.xml"))
                {
                    p2 = (cd)xmlFormat.
                    Deserialize(fStream);
                }
                WriteLine(p2);
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }
        }
    }
}