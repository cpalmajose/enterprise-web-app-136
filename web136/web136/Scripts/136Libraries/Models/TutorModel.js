define([], function () {
    $.support.cors = true;

    // TutorModel Object
    function TutorModel(asyncIndicator) {
        if (asyncIndicator == undefined) {
            asyncIndicator = true;
        }

        // Called by Student Controller
        this.GetListBySchedule = function (id, callback) {
            $.ajax({
                async: asyncIndicator,
                method: "GET",
                url: "http://localhost:5419/Api/TaTutor/GetTutorByCourseSchedule?course_schedule_id=" + id,
                data: "",
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while loading student list.  Is your service layer running?');
                }
            });
        };
    }

    return TutorModel;
});