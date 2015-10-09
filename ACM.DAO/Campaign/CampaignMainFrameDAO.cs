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
    public class CampaignMainFrameDAO
    {
        public List<CampaignMainFrame> CampaignMainFrameInfo(CampaignMainFrame request)
        {
            List<CampaignMainFrame> response = new List<CampaignMainFrame>();
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    if (request != null && request.CampaignId != 0)
                    {
                        response = (from campaignMainFrame in ctx.CampaignMainFrames
                                    where campaignMainFrame.CampaignId == request.CampaignId
                                    select campaignMainFrame).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMainFrameInfo");
                throw;
            }
            return response;
        }

        public CampaignMainFrame CampaignMainFrameInq(CampaignMainFrame request)
        {
            CampaignMainFrame response = new CampaignMainFrame();
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    if (request != null)
                    {
                        response = ctx.CampaignMainFrames.Find(request.CampaignId);
                    }
                    ctx.Configuration.ProxyCreationEnabled = true;
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMainFrameInq");
                throw;
            }
            return response;
        }

        public string CampaignMainFrameAdd(CampaignMainFrame request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.CampaignMainFrames.Add(request);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMainFrameAdd");
                throw;
            }
            return "Successfully added";
        }


        public string CampaignMainFrameMod(CampaignMainFrame request)
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
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMainFrameMod");
                throw;
            }
            return "Successfully updated";
        }

        public string CampaignMainFrameDel(CampaignMainFrame request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;

                    CampaignMainFrame campaign = ctx.CampaignMainFrames.Find(request.CampaignId);

                    ctx.CampaignMainFrames.Remove(campaign);
                    ctx.SaveChanges();
                    ctx.Configuration.ProxyCreationEnabled = true;

                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaignMainFrameDel");
                throw;
            }
            return "Successfully deleted";
        }
    }
}
