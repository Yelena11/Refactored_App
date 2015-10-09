using ACM.DAO;
using ACM.Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Util.ApplicationException;
using System.Diagnostics;

namespace ACM.BO
{
    public class DeploymentPeriodBO
    {
        DeploymentPeriodDAO deploymentPeriodDAO = new DeploymentPeriodDAO();
        public List<GetDropDownListByID> GetAvailableDeploymentPeriod(int campaignId)
        {
            return deploymentPeriodDAO.GetAvailableDeploymentPeriod(campaignId);
        }
        public List<ACM.Model.DeploymentPeriod> DeploymentPeriodInformation(ACM.Model.DeploymentPeriod request)
        {
            return deploymentPeriodDAO.DeploymentPeriodInformation(request);
        }

        public List<ACM.Model.DeploymentPeriod> GetAllDeploymentPeriods()
        {
            DeploymentPeriodDAO  deploymentPeriodDAO = new DeploymentPeriodDAO();
            return deploymentPeriodDAO.GetAllDeploymentPeriods();
        }
        public string InsertAdDeploymentPeriod(int campaignId, int adid, int deploymentPeriodId, bool applyAllDeployments)
        {
            return deploymentPeriodDAO.InsertAdDeploymentPeriod(campaignId, adid, deploymentPeriodId, applyAllDeployments);
        }
        public ACM.Model.DeploymentPeriod DeploymentPeriodAdd(ACM.Model.DeploymentPeriod request)
        {
            try
            {
              
                return deploymentPeriodDAO.DeploymentPeriodAdd(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "DeploymentPeriodAdd");
                throw;
            }
        }

        public ACM.Model.DeploymentPeriod DeploymentPeriodInquiry(ACM.Model.DeploymentPeriod request)
        {
            try
            {
                return deploymentPeriodDAO.DeploymentPeriodInquiry(request);
            }
            catch (Exception ex)
            {
                Error.WriteException(TraceEventType.Error, ex.Message.ToString(), "DeploymentPeriodInquiry");
                throw;
            }
        }

        public string DeploymenPeriodModification(ACM.Model.DeploymentPeriod request)
        {
            string camMod;

            try
            {



                return deploymentPeriodDAO.DeploymentModification(request);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());

            }




        }
    }
}