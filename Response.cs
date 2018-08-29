using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CreditGuard
{
    public class Response
    {
        public string Status { get; set; }
        public string CardId { get; set; }
        public string RequestId { get; set; }
        public DateTime DateTime { get; set; }
        public string Command { get; set; }
        public string TranId { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
        public string UserMessage { get; set; }
        public string AdditionalInfo { get; set; }
        public string Language { get; set; }
        public string Version { get; set; }

        public Response(string webResponse)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(webResponse);

            Status = doc.GetElementsByTagName("status")[0].InnerText;
            if (doc.GetElementsByTagName("cardId")[0] != null)
                CardId = doc.GetElementsByTagName("cardId")[0].InnerText;
            RequestId = doc.GetElementsByTagName("requestId")[0].InnerText;
            DateTime = Convert.ToDateTime(doc.GetElementsByTagName("dateTime")[0].InnerText);
            Command = doc.GetElementsByTagName("command")[0].InnerText;
            TranId = doc.GetElementsByTagName("tranId")[0].InnerText;
            Result = doc.GetElementsByTagName("result")[0].InnerText;
            Message = doc.GetElementsByTagName("message")[0].InnerText;
            UserMessage = doc.GetElementsByTagName("userMessage")[0].InnerText;
            AdditionalInfo = doc.GetElementsByTagName("additionalInfo")[0].InnerText;
            Language = doc.GetElementsByTagName("language")[0].InnerText;
            Version = doc.GetElementsByTagName("version")[0].InnerText;

        }

    }
}
