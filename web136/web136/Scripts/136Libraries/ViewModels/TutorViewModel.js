// StudentViewModel depends on the Models/StudentModel to process requests (Load)
define(['Models/TutorModel'], function (TutorModel) {
    function TutorViewModel() {

        var TutorModelObj = new TutorModel();
        var that = this;
        var initialBind = true;
        var tutorListViewModel = ko.observableArray();

        this.GetListBySchedule = function (id) {

            TutorModelObj.GetListBySchedule(id, function (resultList) {
                tutorListViewModel.removeAll();

                for(var i = 0; i < resultList.length; i++)
                {
                    var str;
                    if (resultList[i].TaType == 0)
                        str = 'TA'
                    else if (resultList[i].TaType == 1)
                        str = 'Tutor'
                    else
                        str = "Grader"

                    tutorListViewModel.push({
                        first: resultList[i].FirstName,
                        last: resultList[i].LastName,
                        type: str
                    });
                }

                if (initialBind) {
                    ko.applyBindings({ viewModel: tutorListViewModel }, document.getElementById("tutorListContent"));
                    initialBind = false; // may not need
                }
                
            });
        };

        /*
        ko.bindingHandlers.DeleteStudent = {
            init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
                $(element).click(function () {
                    var id = viewModel.id;

                    StudentModelObj.Delete(id, function (result) {
                        if (result != "ok") {
                            alert("Error occurred");
                        } else {
                            studentListViewModel.remove(viewModel);
                        }
                    });
                });
            }
        }*/
    }

    return TutorViewModel;
}
);