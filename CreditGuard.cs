using System;
using System.IO;
using System.Net;
using System.Text;

namespace CreditGuard
{
    public class CreditGuard
    {
        Account Account { get; set; }

        public CreditGuard(Account account)
        {
            Account = account;
        }

        public Response AddFirstCharge(string amount, string cardNo, string cardExpiration, string cvv, string cardHolderId)
        {
            return AddChargeAny(amount, cardNo, "", cardExpiration, cvv, cardHolderId);
        }


        public Response AddCharge(string amount, string cardId, string cardExpiration, string cvv, string cardHolderId)
        {
            return AddChargeAny(amount, "", cardId, cardExpiration, cvv, cardHolderId);
        }

        private Response AddChargeAny(string amount, string cardNo, string cardId, string cardExpiration, string cvv, string cardHolderId)
        {
            Charge charge;
            if (cardId.Length > 0)
                charge = new Charge(amount, "", cardId, cardExpiration, cvv, cardHolderId, Account.TerminalId);
            else
                charge = new Charge(amount, cardNo, "", cardExpiration, cvv, cardHolderId, Account.TerminalId);

            var xml = charge.BuildXml(charge);

            var sb = new StringBuilder();
            sb.Append(xml.OuterXml);

            StreamWriter myWriter = null;

            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(Account.CgGatewayUrl);
            objRequest.Method = "POST";
            objRequest.ContentType = "application/x-www-form-urlencoded";

            String result = "";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write("user=" + Account.UserId + "&password=" + Account.Password + "&int_in=" + sb.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();

                // Close and clean up the StreamReader
                sr.Close();
            }

            var response = new Response(result);

            return response;
        }

    }
}
