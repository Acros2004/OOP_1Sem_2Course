using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DeSerialisation
{
    interface Serializer
    {
        void Serialize<T>(T obj, string option, string path);
        void Deserialize<T>(ref T container, string option, string path);
    }
    public class CustomSerializer 
    {
        public static void  Serialize<T>(T obj, string option, string path)
        {
            switch (option.ToUpper())
            {
                case "BIN":
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();

                        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            binaryFormatter.Serialize(fs, obj);
                        }
                        break;
                    }
                case "SOAP":
                    {
                        SoapFormatter soapFormatter = new SoapFormatter();
                        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            soapFormatter.Serialize(fs, obj);
                        }
                        break;
                    }
                case "XML":
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            xmlSerializer.Serialize(fs, obj);
                        }
                        break;
                    }
                case "JSON":
                    {
                        DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));

                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            dataContractJsonSerializer.WriteObject(fs, obj);
                        }
                        break;
                    }
            }

        }
        public static void Deserialize<T>(ref T container, string option, string path)
        {
            switch (option.ToUpper())
            {
                case "BIN":
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();

                        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            container = (T)binaryFormatter.Deserialize(fs);
                        }
                        break;
                    }
                case "SOAP":
                    {
                        SoapFormatter soapFormatter = new SoapFormatter();
                        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            container = (T)soapFormatter.Deserialize(fs);
                        }
                        break;
                    }
                case "XML":
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            container = (T)xmlSerializer.Deserialize(fs);
                        }
                        break;
                    }
                case "JSON":
                    {
                        DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));

                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            container = (T)dataContractJsonSerializer.ReadObject(fs);
                        }

                        break;
                    }
            }

        }
    }
}
