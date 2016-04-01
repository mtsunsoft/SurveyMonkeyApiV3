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
    public class Groups
    {
        public static async Task<List<Group>> GetGroups()
        {
            GroupResponse response = await SurveyMonkeyRequest.GetRequest<GroupResponse>("/groups");
            return response.data;
        }

        public static async Task<GroupDetail> GetGroupDetails(long groupId)
        {
            GroupDetail response = await SurveyMonkeyRequest.GetRequest<GroupDetail>(string.Format("/groups/{0}", groupId));
            return response;
        } 

        public static async Task<List<Member>> GetGroupMembers(long groupId)
        {
            MemberResponse response = await SurveyMonkeyRequest.GetRequest<MemberResponse>("/groups/{0}/members");
            return response.data;
        }

        public static async Task<MemberDetail> GetGroupMemberDetails(long groupId, long memberId)
        {
            MemberDetail response = await SurveyMonkeyRequest.GetRequest<MemberDetail>(string.Format("/groups/{0}/members/{1}", groupId, memberId));
            return response;
        } 
    }
}
