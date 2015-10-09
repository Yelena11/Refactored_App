
// Overall viewmodel for this screen, along with initial state
function CREFViewModel(data, json_regions) {
    var self = this;
    var debug_start = true;
    //debugger;
    this.availableFrequency = ["Weekly", "Monthly", "Quarterly"];
    this.CampaignName = ko.observable();
    this.CampaignDetails = ko.observable();
    this.campaignType = ko.observable("Targeted");
    this.TargetAudience = ko.observable();
    this.Frequency = ko.observable();
    this.radioSelectedFrequency = ko.observable("existing_f");
    this.newFrequencyVal = ko.observable();
    this.FollowUpRequriements = ko.observable();
    this.CampaignStartDate = ko.observable();
    this.CampaingEndDate = ko.observable();
    this.radioSelectedRegions = ko.observable("selected_regions");
    this.OwnRegionsVal = ko.observable();
    this.RequestorName = ko.computed(function () {
        return data.FirstName + " " + data.LastName;
    });
    this.LOBName = ko.observable(data.LOBName);
    this.TargetFileProviderDesc = ko.observableArray(["I will provide the file."]);
    //debugger;
    //definition of tree view
    this.children = ko.observable(new ClsTriStateTreeNode(this, json_regions, 2, null));

    /*save new request on controller will be represented as call to controller with following format
     public JsonResult SaveCampaign(ACM.Model.Campaign campaign, ACM.Model.CampaignTargetFileProvider[] campaignTFPL, ACM.Model.CampaignLocation[] campaignLocList)
     */
    this.SubmitCampaign = function () {
        var campaign = {};
        var arrCampaignTargetFileProvider = [];
        var arrCampaignLocation = [];
        //CampaignID will be assigned before saving new entry
        campaign.CampaignId = '';
        campaign.CampaignName = this.CampaignName();
        campaign.RequestorId = data.Id;
        campaign.LOBId = data.LOBId;
        campaign.CampaignDetails = this.CampaignDetails();
        campaign.CampaignStartDate = this.CampaignStartDate();
        campaign.CampaingEndDate = this.CampaingEndDate();
        campaign.CampaignStatus = "Pending Review";
        campaign.TargetLoadFrequency = "";
        campaign.AssignedPMId = data.Id;
        campaign.CreatedBy = data.Id;
        campaign.ModifiedBy = data.Id;
        campaign.CreatedDate = new Date();
        campaign.ModifiedDate = new Date();

        //if campaign targeted save extra fields and type
        if (this.campaignType() == "Targeted") {
            campaign.CampaignTypeId = "1";
            campaign.TargetAudience = this.TargetAudience();
            campaign.FollowUpRequriements = this.FollowUpRequriements();

            //fill out target file providers
            var CampaignTargetFileProvider = {};
            for (var i = 0; i < this.TargetFileProviderDesc().length; i++) {
                debugger;
                CampaignTargetFileProvider.CampaignId = campaign.CampaignId;
                CampaignTargetFileProvider.TargetFileProviderDesc = this.TargetFileProviderDesc()[i];

                if (this.radioSelectedFrequency() == "existing_f") {
                    CampaignTargetFileProvider.Frequency = this.Frequency();
                }
                else if (this.radioSelectedFrequency() == "new_f") {
                    CampaignTargetFileProvider.Frequency = this.newFrequencyVal();
                }
                CampaignTargetFileProvider.Status = "Active";
                CampaignTargetFileProvider.CreatedBy = campaign.CreatedBy;
                CampaignTargetFileProvider.CreatedDate = campaign.CreatedDate;
                CampaignTargetFileProvider.ModifiedBy = campaign.ModifiedBy;
                CampaignTargetFileProvider.ModifiedDate = campaign.ModifiedDate;
                arrCampaignTargetFileProvider.push(CampaignTargetFileProvider);
            }
        }
        else {
            //if campaign untargeted save untargeted values
            campaign.CampaignTypeId = "2";
            campaign.TargetAudience = "";
            campaign.FollowUpRequriements = "";
        }

        if (this.radioSelectedRegions() == "selected_regions") {
            //debugger;
            //loop through tree nodes to collect region information
            this.setSelectedRegions(this.children(), arrCampaignLocation, campaign);
        }
        else {
            // debugger;
            //get custom value for regions selection.
            var CampaignLocation = {};
            CampaignLocation.CampaignId = campaign.CampaignId;
            CampaignLocation.SuperRegionId = "";
            CampaignLocation.RegionId = "";
            CampaignLocation.StateId = "";
            CampaignLocation.Status = "Active";
            CampaignLocation.SpecifyRegionName = this.OwnRegionsVal();
            CampaignLocation.CreatedBy = campaign.CreatedBy;
            CampaignLocation.CreatedDate = campaign.CreatedDate;
            CampaignLocation.ModifiedBy = campaign.ModifiedBy;
            CampaignLocation.ModifiedDate = campaign.ModifiedDate;
            arrCampaignLocation.push(CampaignLocation);
        }
        //  debugger;
        $.ajax({
            type: "POST",
            url: "SaveCampaign",
            data: JSON.stringify({ campaign: campaign, campaignTFPL: arrCampaignTargetFileProvider, campaignLocList: arrCampaignLocation }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                alert("Saved Sucessfully");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                //   console.log(xhr.status);
                //   console.log(thrownError);
            }
        });

        if (debug_start) {
            // alert(hi);
            //console.log(this.CampaignName());
            //console.log(this.CampaignDetails());
            //console.log(this.campaignType());
            //console.log(this.Frequency());
            //console.log(this.radioSelectedFrequency());
            //console.log(this.FollowUpRequriements());
            //console.log(this.CampaignStartDate());
            //console.log(this.CampaingEndDate());
            //console.log(this.radioSelectedRegions());
            //console.log(this.OwnRegionsVal());
            //console.log(this.TargetFileProviderDesc().join(","));
            //debugger;
            //this.printChildStatus(this.children());
        }
    };

    ///recursive print for debug purpose only
    this.printChildStatus = function (parent) {
        //debugger;
        if (parent.HasChild() && parent.ChildNodes() != null && parent.ChildNodes().length > 0) {
            for (var childCtr = 0 ; childCtr < parent.ChildNodes().length; childCtr++) {
                this.printChildStatus(parent.ChildNodes()[childCtr]);
            }
        }
        if (parent.CurrentStatus == 2) {
            //    console.log(parent.CurrentNode().DisplayID() + " - " + parent.CurrentNode().DisplayText() + " - " + parent.CurrentStatus);
        }
    }

    ///loop through child nodes to get selected regions assigned to new campaign.
    this.setSelectedRegions = function (parent, arrCLocation, campaign) {
        if (parent.HasChild() && parent.ChildNodes() != null && parent.ChildNodes().length > 0) {
            for (var childCtr = 0 ; childCtr < parent.ChildNodes().length; childCtr++) {
                this.setSelectedRegions(parent.ChildNodes()[childCtr], arrCLocation, campaign);
            }
        }

        if (parent.CurrentStatus == 2) {
            //fill the CampaignLocation array with selected regions
            var arrRegionSplit = parent.CurrentNode().DisplayID().split("$");
            if (arrRegionSplit.length > 1) {
                var CampaignLocation = {};
                //  debugger;
                CampaignLocation.CampaignId = campaign.CampaignId;
                CampaignLocation.SuperRegionId = arrRegionSplit[0];
                CampaignLocation.RegionId = arrRegionSplit[1];;
                CampaignLocation.StateId = "";
                CampaignLocation.Status = "Active";
                CampaignLocation.SpecifyRegionName = "";
                CampaignLocation.CreatedBy = campaign.CreatedBy;
                CampaignLocation.CreatedDate = campaign.CreatedDate;
                CampaignLocation.ModifiedBy = campaign.ModifiedBy;
                CampaignLocation.ModifiedDate = campaign.ModifiedDate;
                arrCLocation.push(CampaignLocation);
            }
        }
    }
}