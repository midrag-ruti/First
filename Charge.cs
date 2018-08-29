using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CreditGuard
{
    class Charge
    {
        public Charge(string amount, string cardNo, string cardId, string cardExpiration, string cvv, string cardHolderId, string terminalId)
        {
            Language = "Eng";
            Command = "doDeal";
            TransactionCode = "phone";
            TransactionType = "debit";
            CreditType = "RegularCredit";
            Validation = "AutoComm";
            Currency = "ILS";
            Version = "1000";

            Total = amount;
            CardNo = cardNo;
            CardId = cardId;
            CardExpiration = cardExpiration;
            Cvv = cvv;
            Id = cardHolderId;
            TerminalNumber = terminalId;
        }

        public string Command { get; set; }
        public string Language { get; set; }
        public string Version { get; set; }
        public string RequestId { get; set; }
        public string TerminalNumber { get; set; }
        public string AuthNumber { get; set; }
        public string TransactionCode { get; set; }
        public string TransactionType { get; set; }
        public string Total { get; set; }
        public string CreditType { get; set; }
        public string CardNo { get; set; }
        public string CardId { get; set; }
        public string Cvv { get; set; }
        public string CardExpiration { get; set; }
        public string Validation { get; set; }
        public string NumberOfPayments { get; set; }
        public string[] UserData { get; set; }
        public string Currency { get; set; }
        public string FirstPayment { get; set; }
        public string Id { get; set; }
        public string PeriodicalPayment { get; set; }

        public XmlDocument BuildXml(Charge charge)
        {
            var xml = new XmlDocument();
            var rootNode = xml.CreateElement("ashrait");
            xml.AppendChild(rootNode);
            var requestNode = xml.CreateElement("request");
            rootNode.AppendChild(requestNode);
            var languageNode = xml.CreateElement("language");
            languageNode.InnerText = charge.Language;
            requestNode.AppendChild(languageNode);
            var commandNode = xml.CreateElement("command");
            commandNode.InnerText = charge.Command;
            requestNode.AppendChild(commandNode);
            var requestIdNode = xml.CreateElement("requestId");
            requestIdNode.InnerText = charge.RequestId;
            requestNode.AppendChild(requestIdNode);
            var versionNode = xml.CreateElement("version");
            versionNode.InnerText = charge.Version;
            requestNode.AppendChild(versionNode);
            var actionNode = xml.CreateElement("doDeal");
            requestNode.AppendChild(actionNode);
            var chargeNode = xml.CreateElement("terminalNumber");
            chargeNode.InnerText = charge.TerminalNumber;
            actionNode.AppendChild(chargeNode);
            var authNumberNode = xml.CreateElement("authNumber");
            authNumberNode.InnerText = charge.AuthNumber;
            actionNode.AppendChild(authNumberNode);
            var transactionCodeNode = xml.CreateElement("transactionCode");
            transactionCodeNode.InnerText = charge.TransactionCode;
            actionNode.AppendChild(transactionCodeNode);
            var transactionTypeNode = xml.CreateElement("transactionType");
            transactionTypeNode.InnerText = charge.TransactionType;
            actionNode.AppendChild(transactionTypeNode);
            var totalNode = xml.CreateElement("total");
            totalNode.InnerText = charge.Total;
            actionNode.AppendChild(totalNode);
            var creditTypeNode = xml.CreateElement("creditType");
            creditTypeNode.InnerText = charge.CreditType;
            actionNode.AppendChild(creditTypeNode);
            if (charge.CardNo != null)
            {
                var cardNoNode = xml.CreateElement("cardNo");
                cardNoNode.InnerText = charge.CardNo;
                actionNode.AppendChild(cardNoNode);
            }
            if (charge.CardId != null)
            {
                var cardIdNode = xml.CreateElement("cardId");
                cardIdNode.InnerText = charge.CardId;
                actionNode.AppendChild(cardIdNode);
            }
            var cvvNode = xml.CreateElement("cvv");
            cvvNode.InnerText = charge.Cvv;
            actionNode.AppendChild(cvvNode);
            var cardExpirationNode = xml.CreateElement("cardExpiration");
            cardExpirationNode.InnerText = charge.CardExpiration;
            actionNode.AppendChild(cardExpirationNode);
            var validationNode = xml.CreateElement("validation");
            validationNode.InnerText = charge.Validation;
            actionNode.AppendChild(validationNode);
            var numberOfPaymentsNode = xml.CreateElement("numberOfPayments");
            numberOfPaymentsNode.InnerText = charge.NumberOfPayments;
            actionNode.AppendChild(numberOfPaymentsNode);
            if (UserData != null && UserData.Length > 0)
            {
                var customerDataNode = xml.CreateElement("customerData");
            }
            else
                actionNode.AppendChild(xml.CreateElement("customerData"));
            var currencyNode = xml.CreateElement("currency");
            currencyNode.InnerText = charge.Currency;
            actionNode.AppendChild(currencyNode);
            var firstPaymentNode = xml.CreateElement("firstPayment");
            firstPaymentNode.InnerText = charge.FirstPayment;
            actionNode.AppendChild(firstPaymentNode);
            var idNode = xml.CreateElement("id");
            idNode.InnerText = charge.Id;
            actionNode.AppendChild(idNode);
            var periodicalPaymentNode = xml.CreateElement("periodicalPayment");
            periodicalPaymentNode.InnerText = charge.PeriodicalPayment;
            actionNode.AppendChild(periodicalPaymentNode);



            return xml;
        }
    }
}
