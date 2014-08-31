// StudentViewModel depends on the Models/StudentModel to process requests (Load)
define(['Models/CapeModel'], function (CapeModel) {
    function CapeViewModel() {

        var CapeModelObj = new CapeModel();
        var that = this;
        var initialBind = true;
        var CapeListViewModel = ko.observableArray();

        this.GetCapeByCourse = function (id) {

            CapeModelObj.GetCapeByCourse(id, function (resultList) {
                
                var list = new Array();
                try{
                    for (var i = 0; i < resultList.length; i++) {
                    
                        list[i] = {
                            quarter: resultList[i].CapeDetail.Quarter,
                            year: resultList[i].CapeDetail.Year,
                            instructor: resultList[i].CapeDetail.Instructor.LastName + ", " + resultList[i].CapeDetail.Instructor.FirstName,
                            a: resultList[i].As,
                            b: resultList[i].Bs,
                            c: resultList[i].Cs,
                            d: resultList[i].Ds,
                            f: resultList[i].Fs,
                            total: resultList[i].TotalReviews,
                            avg: resultList[i].AverageReview
                        };
                    }
                }
                catch(e){
                    alert(e)
                }

                if (initialBind) {
                    ko.applyBindings({ viewModel: list }, document.getElementById("divCapeDetails"));
                    initialBind = false;
                }
            });
        };
    }

    return CapeViewModel;
}
);