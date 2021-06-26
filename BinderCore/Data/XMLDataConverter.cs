using System;
using System.Collections.Generic;
using System.Xml;
using Binder.Properties;
using Binder.Task;
using Binder.Task.Factories;

namespace Binder.Data
{
    /// <summary>
    /// Data convertion class for XML. This class assumes, that XML input data order is like in ITask interface.
    /// </summary>
    public class XMLDataConverter : IDataConverter
    {
        /// <summary>
        /// IDataConverter-inherited property. This class is not using it.
        /// </summary>
        public char Separator
        {
            get => throw new NotImplementedException("This class is not using it.");
            set => throw new NotImplementedException("This class is not using it.");
        }

        /// <summary>
        /// Checks if given <see cref="string"/> data is <see cref="XmlDeclaration"/> data.
        /// </summary>
        /// <param name="data"><see cref="string"/> object with data to check.</param>
        /// <returns><see cref="true"/> if given data is declaration, <see cref="false"/> if not.</returns>
        private bool CheckIfXmlDeclaration(string data)
        {
            var obj = new XmlDocument();
            var declar = obj.CreateXmlDeclaration("1.0", "utf-8", "yes");

            if (declar.OuterXml == data)
                return true;
            else return false;
        }

        /// <summary>
        /// Checks if given data string is valid XML string.
        /// </summary>
        /// <param name="data">XML string object to check.</param>
        /// <returns>XmlDocument object with loaded string from argument. Null if error.</returns>
        private XmlDocument CheckXMLFormat(string data)
        {
            var obj = new XmlDocument();

            try
            {
                // LoadXml throws XmlException, if data is not correctly formated:
                obj.LoadXml(data);
            }
            catch (XmlException)
            {
                return null;
            }

            return obj;
        }

        /// <summary>
        /// Converts XML data from string object to ITask-compatible object, provided in argument.
        /// </summary>
        /// <param name="dest">ITask-compatible object to fill data with.</param>
        /// <param name="data">String object with XML data.</param>
        /// <returns>ITask-compatible object from argument, filled in with converted XML data. Null if error, or ITask object provided with declaration in Name.</returns>
        public ITask ToObject(ITask dest, string data)
        {
            if(CheckIfXmlDeclaration(data))
            {
                dest.Name = Settings.Default.DefaultStorageSetting;
                return dest;
            }

            if (CheckXMLFormat(data) == null)
                return null;

            var xml = new XmlDocument();
            xml.LoadXml(data);

            // Filling in ITask object, order defined by ITask interface:
            try
            {
                dest.Name = xml.DocumentElement.GetAttribute(nameof(dest.Name));
                dest.Description = xml.DocumentElement.GetAttribute(nameof(dest.Description));
                dest.StartDate = DateTime.Parse(xml.DocumentElement.GetAttribute(nameof(dest.StartDate)));
                dest.EndDate = DateTime.Parse(xml.DocumentElement.GetAttribute(nameof(dest.EndDate)));
                dest.Complete = bool.Parse(xml.DocumentElement.GetAttribute(nameof(dest.Complete)));
                dest.Category = xml.DocumentElement.GetAttribute(nameof(dest.Category));
            }
            catch (Exception)
            {
                return null;
            }

            return dest;
        }

        /// <summary>
        /// Converts IList-compatible list of XML strings to IList-conpatible list of ITask-compatible objects.
        /// This methods uses standard generic list.
        /// </summary>
        /// <param name="dest">ITask-compatible object to fill with data.</param>
        /// <param name="data">XML string object with data in it.</param>
        /// <returns>Standard generic list of ITask objects, with filled data in. If there was an error, list will have null objects in.</returns>
        public IList<ITask> ToObject(ITaskFactory factory, IList<string> data)
        {
            var list = new List<ITask>();

            foreach (var task in data)
            {
                var obj = ToObject(factory.GetTask(ETask.Standard), task);
                list.Add(obj);
            }

            return list;
        }

        /// <summary>
        /// Converts ITask-compatible object to XML string.
        /// </summary>
        /// <param name="data">ITask-compatible object with data.</param>
        /// <returns>XML string object, ordered with ITask sequence of data. Null if error.</returns>
        public string ToObject(ITask data)
        {
            var xml = CheckXMLFormat(Settings.Default.XMLTaskFormat);

            if (string.IsNullOrEmpty(data.Name)) return null;

            xml.DocumentElement.SetAttribute(nameof(data.Name), data.Name);
            xml.DocumentElement.SetAttribute(nameof(data.Description), data.Description);
            xml.DocumentElement.SetAttribute(nameof(data.StartDate), data.StartDate.ToString());
            xml.DocumentElement.SetAttribute(nameof(data.EndDate), data.EndDate.ToString());
            xml.DocumentElement.SetAttribute(nameof(data.Complete), data.Complete.ToString());
            xml.DocumentElement.SetAttribute(nameof(data.Category), data.Category);

            return xml.InnerXml;
        }

        /// <summary>
        /// Converts IList-compatible list of ITask-compatible objects to IList-compatible list of strings.
        /// </summary>
        /// <param name="data">IList-compatible list of ITask-compatible objects.</param>
        /// <returns>Standard generic list of string objects, with filled data in. If there was an error, list will have null objects in.</returns>
        public IList<string> ToObject(IList<ITask> data)
        {
            var list = new List<string>();

            foreach (var task in data)
            {
                var obj = ToObject(task);
                list.Add(obj);
            }

            return list;
        }

        /// <summary>
        /// Converts XML data string to ICategory-compatible object. Do not use this method.
        /// </summary>
        /// <param name="dest">ICategory-compatible object to fill data with.</param>
        /// <param name="data">XML string object with data.</param>
        /// <returns>ICategory-compatible object provided in argument, filled with data.  If there was an error, list will have null objects in.</returns>
        public ICategory ToObject(ICategory dest, string data)
        {
            throw new NotImplementedException("To be implemented in next versions.");
        }

        /// <summary>
        /// Converts IList-compatible list of XML data strings to IList-compatible list of ICategory-compatible objects. Do not use this method.
        /// </summary>
        /// <param name="dest">IList-compatible list of ICategory-compatible objects to fill data with.</param>
        /// <param name="data">IList-compatible list of XML data strings with data.</param>
        /// <returns>Standard generic list of ICategory-compatible objects, with filled data in. If there was an error, list will have null objects in.</returns>
        public IList<ICategory> ToObject(ICategory dest, IList<string> data)
        {
            throw new NotImplementedException("To be implemented in next versions.");
        }

        /// <summary>
        /// Converts ICategory-compatilbe object to XML data string object.
        /// </summary>
        /// <param name="data">ICategory-compatilbe object with data.</param>
        /// <returns>XML string object with data.</returns>
        public string ToObject(ICategory data)
        {
            throw new NotImplementedException("To be implemented in next versions.");
        }

        /// <summary>
        /// Converts IList-compatible list of ICategory-compatilbe objects to IList-compatible list of XML data string objects.
        /// </summary>
        /// <param name="data">IList-compatible list of ICategory-compatilbe objects with data.</param>
        /// <returns>IList-compatible list of string objects. If there was an error, list will have null objects in.</returns>
        public IList<string> ToObject(IList<ICategory> data)
        {
            throw new NotImplementedException("To be implemented in next versions.");
        }
    }
}
