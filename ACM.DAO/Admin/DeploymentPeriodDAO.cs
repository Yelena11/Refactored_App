using ACM.Model.CustomModel;
using ACM.Util.ApplicationException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Model;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ACM.DAO
{
    public class DeploymentPeriodDAO
    {
        private ACM_Redesign2014Context ACMContex = new ACM_Redesign2014Context();
        public List<GetDropDownListByID> GetAvailableDeploymentPeriod(int campaignId)
        {
            try
            {
                List<GetDropDownListByID> listItems = new List<GetDropDownListByID>();
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    listItems = (ctx.Database.SqlQuery<GetDropDownListByID>("exec SP_DeploymentPeriod @campaignId",
                    new SqlParameter("campaignId", campaignId)
                  )).ToList();
                }
                return listItems;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetAvailableDeploymentPeriod");
                throw;
            }
        }

        public List<GetDropDownListByID> GetFutureDeploymentPeriod(int campaignId, int deploymentPeriodId)
        {
            try
            {
                List<GetDropDownListByID> listItems = new List<GetDropDownListByID>();
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    listItems = (ctx.Database.SqlQuery<GetDropDownListByID>("exec SP_GetFutureDeploymentPeriod @campaignId,@deploymentPeriodId",
                    new SqlParameter("campaignId", campaignId),
                     new SqlParameter("deploymentPeriodId", deploymentPeriodId)
                  )).ToList();
                }
                return listItems;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetAvailableDeploymentPeriod");
                throw;
            }
        }

        public List<ACM.Model.DeploymentPeriod> DeploymentPeriodInformation(ACM.Model.DeploymentPeriod request)
        {
            List<ACM.Model.DeploymentPeriod> response = new List<ACM.Model.DeploymentPeriod>();
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {

                    ctx.Configuration.ProxyCreationEnabled = false;
                    if (request != null)
                    {
                        response = (from deploymentperiod in ctx.DeploymentPeriods
                                    select deploymentperiod).ToList();
                    }

                    ctx.Configuration.ProxyCreationEnabled = true;

                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "DeploymentPeriodInformation");
                throw;
            }

            return response;
        }
        public List<ACM.Model.DeploymentPeriod> GetAllDeploymentPeriods()
        {
            try
            {
                ACMContex.Configuration.LazyLoadingEnabled = true;

                ACMContex.Configuration.ProxyCreationEnabled = false;
                List<ACM.Model.DeploymentPeriod> deploymentPeriodList = ACMContex.DeploymentPeriods.OrderByDescending(t => t.DeploymentStartDate).ToList();

                ACMContex.Configuration.ProxyCreationEnabled = true;

                return deploymentPeriodList;
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "GetAllDeploymentPeriods");
                throw;
            }
        
        }

        public string InsertAdDeploymentPeriod(int campaignId, int adid, int deploymentPeriodId, bool applyAllDeployments)
        {
            string retVal = string.Empty;
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    int applyToAllDeployment = 0;
                    if (applyAllDeployments)
                        applyToAllDeployment = 1;
                    ACM.DAO.DeploymentPeriodDAO dao = new DeploymentPeriodDAO();
                    var allDeploymentPeriods = dao.GetFutureDeploymentPeriod(campaignId, deploymentPeriodId);
                    List<string> ads = new List<string>();

                    foreach (var item in allDeploymentPeriods)
                    {
                        ads.Add(item.ID.ToString());
                    }
                    string adList = string.Join(",", ads.ToList());

                    ctx.Database.ExecuteSqlCommand("SP_AddDeploymentPeriod @CampaignId, @AdId, @DeploymentPeriodId,@DeploymentPeriodIds, @applyAll",
                        new SqlParameter("CampaignId", campaignId),
                        new SqlParameter("AdId", adid),
                        new SqlParameter("DeploymentPeriodId", deploymentPeriodId),
                        new SqlParameter("DeploymentPeriodIds", adList),
                        new SqlParameter("applyAll", applyToAllDeployment)
                      );

                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "InsertAdDeploymentPeriod");
                throw;
            }
            return retVal;
        }

        public ACM.Model.DeploymentPeriod DeploymentPeriodAdd(ACM.Model.DeploymentPeriod request)
        {
            ACM.Model.DeploymentPeriod response = new ACM.Model.DeploymentPeriod();
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    request.CreatedDate = DateTime.Now;


                    ctx.DeploymentPeriods.Add(request);
                    ctx.SaveChanges();
                    ctx.Configuration.ProxyCreationEnabled = false;
                    // IQueryable<ACM.Model.Campaign> response1 = ctx.Campaigns.Last();
                    response = (from deploymentperiod in ctx.DeploymentPeriods 
                                orderby deploymentperiod.DeploymentPeriodId descending
                                select deploymentperiod).First();



                    ctx.Configuration.ProxyCreationEnabled = true;
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "DeploymentPeriodAdd");
                throw;
            }
            return response;
        }


        public ACM.Model.DeploymentPeriod DeploymentPeriodInquiry(ACM.Model.DeploymentPeriod request)
        {
            ACM.Model.DeploymentPeriod response = new ACM.Model.DeploymentPeriod();
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    ctx.Configuration.LazyLoadingEnabled = true;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    if (request != null)
                    {
                        response = ctx.DeploymentPeriods.Find(request.DeploymentPeriodId);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "DeploymentPeriodInquiry");
                throw;
            }
            return response;
        }

        public string DeploymentModification(ACM.Model.DeploymentPeriod request)
        {
            try
            {
                using (ACM_Redesign2014Context ctx = new ACM_Redesign2014Context())
                {
                    request.ModifiedDate = DateTime.Now;
                    ctx.Entry(request).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "DeploymentModification");
                throw;
            }
            return "Successfully updated";
        }
    }
}