function ClsTriStateTreeNode(parent, cNode, lavelToExpanded, currentLavel) {
    var Self = this;
    Self.CurrentNode = ko.observable(); //ClsTriStateCheckBox
    Self.ChildNodes = ko.observableArray([]);  //Array of ClsTriStateTreeNode
    Self.HasChild = ko.observable(false);
    var isExpandedChild = false;


    if (lavelToExpanded == null) lavelToExpanded = 0;
    if (currentLavel == null) currentLavel = 1;
    if (lavelToExpanded == 0) {
        isExpandedChild = false;
    } else if (lavelToExpanded < 0) {
        isExpandedChild = true;
    } else if (lavelToExpanded >= currentLavel) {
        isExpandedChild = true;
    } else {
        isExpandedChild = false;
    }


    Self.ShowChild = ko.observable(isExpandedChild);
    Self.CurrentStatus = 0;


    Self.ExpandChild = function () {
        Self.ShowChild(!Self.ShowChild());
    }

    Self.ResetStatus = function () {
        if (
            parent != null
            && parent.ResetStatus != null
            ) {
            parent.ResetStatus();
        }
        else {
            //Update current status acording child status to reset parent
            Self.SetTriStatus();
        }

    }

    // Bitwise OR 
    // UNCHECKED-1(01) & CHECKED-2(10) = INDETERMINATE 3(11)
    // UNCHECKED-1(01) & UNCHECKED-1(01) = UNCHECKED 1(01)
    // CHECKED-2(10) & CHECKED-2(10) = INDETERMINATE 2(10)
    Self.SetTriStatus = function () {
        Self.CurrentStatus = 0;
        if (Self.HasChild() && Self.ChildNodes != null && Self.ChildNodes().length > 0) {
            for (var childCtr = 0 ; childCtr < Self.ChildNodes().length; childCtr++) {
                //Use Recurtion to update child first then parent
                Self.ChildNodes()[childCtr].SetTriStatus();
                //After changing child status acording their child status, 
                //Update current status acording child status to reset parent
                Self.CurrentStatus |= Self.ChildNodes()[childCtr].CurrentNode().State();
            }
            Self.CurrentNode().LoadStatus(Self.CurrentStatus);
        } else {
            // If dont have child then return 
            Self.CurrentStatus = Self.CurrentNode().State();
        }
    }

    //Update All Child of current tree with updateStatus para. 
    //Call this method to change all child to updateStatus when any node status change to updateStatus    
    Self.UpdateChildStatus = function (updateStatus) {
        if (Self.HasChild() && Self.ChildNodes != null && Self.ChildNodes().length > 0) {
            for (var childCtr = 0 ; childCtr < Self.ChildNodes().length; childCtr++) {
                Self.ChildNodes()[childCtr].UpdateChildStatus(updateStatus);
            }
        }
        Self.CurrentNode().LoadStatus(updateStatus);
    }

    //Loading Data To Tree
    if (cNode != null) {
        Self.CurrentNode(new ClsTriStateCheckBox(Self, cNode));
        if (cNode.Childs != null && cNode.Childs.length > 0) {
            for (var childCtr = 0 ; childCtr < cNode.Childs.length; childCtr++) {
                //Use Recurtion to create list of Self object
                Self.ChildNodes.push(new ClsTriStateTreeNode(Self, cNode.Childs[childCtr], lavelToExpanded, currentLavel + 1));
            }
        }
        Self.HasChild(Self.ChildNodes() != null && Self.ChildNodes().length > 0 ? true : false)
        if (
             !(parent != null
              && parent.ResetStatus != null)
              ) {
            //Update current status acording child status to reset parent
            Self.SetTriStatus();
        }
    }
}