using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Razor.Language;

namespace _7___Demo___Data_Protection.Data_Protection
{
    /// <summary>
    /// Sample custom key ring storage class, used for demo-purposes in this exercise
    /// </summary>
    public class CustomKeyRingStorage : IXmlRepository
    {
        public string _keyringPathAndFileName;

        public CustomKeyRingStorage()
        {
            _keyringPathAndFileName = Directory.GetCurrentDirectory() + "\\MyKeyRing.xml";
        }

        /// <summary>
        /// Gets all top-level XML elements in the repository.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<XElement> GetAllElements()
        {
            var entries = new List<XElement>();
            XDocument doc = new XDocument();
            if (File.Exists(_keyringPathAndFileName))
            {
                doc = XDocument.Load(_keyringPathAndFileName);

                foreach (XElement node in doc.Root.Elements())
                {
                    entries.Add(node);
                }
            }

            return entries;
        }

        /// <summary>
        /// Adds a top-level XML element to the repository.
        /// </summary>
        /// <param name="element">The element to add</param>
        /// <param name="friendlyName">An optional name to be associated with the XML element.</param>
        public void StoreElement(XElement element, string friendlyName)
        {
            XDocument doc;
            if (File.Exists(_keyringPathAndFileName))
            {
                doc = XDocument.Load(_keyringPathAndFileName);
                doc.Root.Add(element);
            }
            else
            {
                doc = new XDocument();
                var root = new XElement("root");
                doc.Add(root);
                root.Add(element);
            }

            doc.Save(_keyringPathAndFileName);
        }
    }
}
