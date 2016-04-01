using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyMonkeyApiV3.Models;
using SurveyMonkeyApiV3.Models.Responses;
using SurveyMonkeyApiV3.Modules.Networking;

namespace SurveyMonkeyApiV3
{
    public class Collectors
    {
        public static async Task<Collector> GetCollectorDetails(long collectorId)
        {
            Collector response = await SurveyMonkeyRequest.GetRequest<Collector>(string.Format("/collectors/{0}", collectorId));
            return response;
        }

        public static async Task<List<Message>> GetCollectorMessages(long collectorId)
        {
            BaseResponse<Message> response = await SurveyMonkeyRequest.GetRequest<BaseResponse<Message>>(string.Format("/collectors/{0}/messages", collectorId));
            return response.data;
        }

        public static async Task<Message> GetCollectorMessageDetails(long collectorId, long messageId)
        {
            Message response = await SurveyMonkeyRequest.GetRequest<Message>(string.Format("/collectors/{0}/messages/{1}", collectorId, messageId));
            return response;
        } 

        public static async Task<List<Recipient>> GetCollectorMessageRecipients(long collectorId, long messageId)
        {
            BaseResponse<Recipient> response = await SurveyMonkeyRequest.GetRequest<BaseResponse<Recipient>>(string.Format("/collectors/{0}/messages/{1}/recipients", collectorId, messageId));
            return response.data;
        }

        public static async Task<Recipient> GetCollectorMessageRecipientDetails(long collectorId, long messageId, long recipientId)
        {
            Recipient response = await SurveyMonkeyRequest.GetRequest<Recipient>(string.Format("/collectors/{0}/messages/{1}/recipients/{2}", collectorId, messageId, recipientId));
            return response;
        }
    }
}
