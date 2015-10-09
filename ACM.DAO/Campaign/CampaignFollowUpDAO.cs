using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.DAO.Campaign
{
    public class CampaignFollowUpDAO
    {
        public List<CampaignFollowUp> CampaignFollowUpInfo(CampaignFollowUp request)
        {
            List<CampaignFollowUp> response = new List<CampaignFollowUp>();
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    if (request != null && request.CampaignId != 0)
                    {
                        response = (from campaignFollowUp in ctx.CampaignFollowUps
                                    where campaignFollowUp.CampaignId == request.CampaignId
                                    select campaignFollowUp).ToList();
                    }
                    else
                        response = (from campaign in ctx.CampaignFollowUps
                                    select campaign).ToList();
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignFollowUpInfo");
                throw;
            }
            return response;
        }

        public CampaignFollowUp CampaignFollowUpInq(CampaignFollowUp request)
        {
            CampaignFollowUp response = new CampaignFollowUp();
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    if (request != null)
                    {
                        response = ctx.CampaignFollowUps.Find(request.CampaignId);
                    }
                    ctx.Configuration.ProxyCreationEnabled = true;
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignFollowUpInq");
                throw;
            }
            return response;
        }

        public string CampaignFollowUpAdd(CampaignFollowUp request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.CampaignFollowUps.Add(request);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignFollowUpAdd");
                throw;
            }
            return "Successfully added";
        }


        public string CampaignFollowUpMod(CampaignFollowUp request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.Entry(request).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignFollowUpMod");
                throw;
            }
            return "Successfully updated";
        }

        public string CampaignFollowUpDel(CampaignFollowUp request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    CampaignFollowUp campaign = ctx.CampaignFollowUps.Find(request.CampaignId);
                    ctx.CampaignFollowUps.Remove(campaign);
                    ctx.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignFollowUpDel");
                throw;
            }
            return "Successfully deleted";
        }

    }
}
