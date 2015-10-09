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
    public class CampaignTargetFileProviderDAO
    {
        public List<CampaignTargetFileProvider> CampaigTargetFileInfo(CampaignTargetFileProvider request)
        {
            List<CampaignTargetFileProvider> response = new List<CampaignTargetFileProvider>();
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    if (request != null && request.CampaignId != 0)
                    {
                        response = (from campaignTargetFileProvider in ctx.CampaignTargetFileProviders
                                    where campaignTargetFileProvider.CampaignId == request.CampaignId
                                    select campaignTargetFileProvider).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaigTargetFileInfo");
                throw;
            }
            return response;
        }

        public CampaignTargetFileProvider CampaigTargetFileInq(CampaignTargetFileProvider request)
        {
            CampaignTargetFileProvider response = new CampaignTargetFileProvider();
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    if (request != null)
                    {
                        response = ctx.CampaignTargetFileProviders.Find(request.CampaignId);
                    }
                    ctx.Configuration.ProxyCreationEnabled = true;
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaigTargetFileInq");
                throw;
            }
            return response;
        }

        public string CampaigTargetFileAdd(CampaignTargetFileProvider request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.CampaignTargetFileProviders.Add(request);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaigTargetFileAdd");
                throw;
            }
            return "Successfully added";
        }


        public string CampaigTargetFileMod(CampaignTargetFileProvider request)
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
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaigTargetFileMod");
                throw;
            }
            return "Successfully updated";
        }

        public string CampaigTargetFileDel(CampaignTargetFileProvider request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    CampaignTargetFileProvider campaign = ctx.CampaignTargetFileProviders.Find(request.CampaignId);
                    ctx.CampaignTargetFileProviders.Remove(campaign);
                    ctx.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "CampaigTargetFileDel");
                throw;
            }
            return "Successfully deleted";
        }

    }
}
