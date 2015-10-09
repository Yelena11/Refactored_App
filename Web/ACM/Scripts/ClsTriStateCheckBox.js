



//ViewModel for Tri Stae CheckBox
function ClsTriStateCheckBox(parent,cNode) {
    var Self = this;

    //To hold current State of TriStateCheckBox object
    Self.State = ko.observable();
   
    //Properties to bind Display Text
    Self.DisplayText = ko.observable(); // To display trimmed text
    Self.Title = ko.observable(); // To display text on mouse over
    Self.DisplayID = ko.observable(); // To display trimmed text

    //Defime Enums for tristate
    Self.EnumState = {
        UNCHECKED: ko.observable(0x1),    //  int  = 1 in decimal and 01 in binary
        CHECKED: ko.observable(0x2),      //  int  = 2 in decimal and 10 in binary
        INDETERMINATE: ko.observable(0x3) //  int  = 3 in decimal and 11 in binary
    };

    // Change State Function
    Self.LoadStatus = function (inputState) {
        if (inputState != null) {
            switch (inputState) {
                case 2:
                    Self.State(Self.EnumState.CHECKED());
                    break;
                case 1:
                    Self.State(Self.EnumState.UNCHECKED());
                    break;
                case 3:
                    Self.State(Self.EnumState.INDETERMINATE());
                    break;
            }

        }
    }

    // onclick event - bind with checkbox control
    Self.ChangeStatus = function () {
        var updateStatus
        switch (Self.State()) {
            case Self.EnumState.UNCHECKED():
                Self.LoadStatus(2);
                updateStatus = 2;
                break;
            case Self.EnumState.CHECKED():
                Self.LoadStatus(1);
                updateStatus = 1;
                break;
            case Self.EnumState.INDETERMINATE():
                Self.LoadStatus(2);
                updateStatus = 2;
                break;
        }
        if (parent != null &&  parent.ResetStatus != null)
        {
            //Call current node method to update all childs status with updateStatus.
            parent.UpdateChildStatus(updateStatus);
            //Call parent to Reset Status acording current node 
            parent.ResetStatus();
        }
    }

    Self.UpdateIndeterminate = function () {
        Self.LoadStatus(3);
    }

    //Load Default Value when initialise
    if (cNode != null) {
        if (cNode.defaultState != null) {
            //  1 then UNCHECKED 
            //  2 then CHECKED
            Self.LoadStatus(cNode.defaultState ? 2 : 1);
        }
        else { Self.LoadStatus(1) }

        if (cNode.displayText != null) {
            Self.DisplayText(cNode.displayText);
            Self.Title(cNode.displayText);
        }

        if (cNode.displayID != null) {
            Self.DisplayID(cNode.displayID);
        }
    }
}



