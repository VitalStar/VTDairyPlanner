$(document).ready(function() {

    $("#Tree").on('click', 'div.folderType.ExpandClosed', function() {
        //callTaskGetChildrens($(this).attr("id"));
    });

    // Tree Close Folder
    $("#Tree").on('click', 'div.folderType.ExpandOpen', function() {
        //$(this).removeClass('ExpandOpen');
       // $(this).addClass('ExpandClosed');
       // $(this).parent().children('ul.treeSortable').remove();

    });

    callTaskGetRoot();
});

function callTaskGetRoot() {
    jQuery.ajax({
        type: "POST",
        url: "dairy.asmx/GetRootTask",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        cache: false,
        success: function (msg) {
            if (msg.d) {
                PostBack_UIShowRootTasks(msg.d);
            }
            else {
                alert("Method callGetRootTasks: getTasksAJAX failed callback : " + msg.toString());
            }
        },
        error: function (xhr, status, error) {
            alert("Method : callGetRootTasks  failed call - " + xhr + " | status : " + status + " error " + error);
        }
    });
}


function PostBack_UIShowRootTasks(taskData) {
    var rootDiv = $("#Tree");
    var rootUl = $("<ul>").addClass('treeSortable').appendTo(rootDiv);

    var task = ConvertToTask(taskData);
    var taskUi = UITaskToLiElement(task);
    if (taskUi.length == 0) {
        alert('UIShowRootTasks ' + task.Title + 'add problems');
    }
    rootUl.append(taskUi);


    AppendTreeSortable();
}

function ConvertToTask(data) {
    var task = new Task(
        data.Id,
        data.ParentId,
        data.Title,
        data.Description,
        data.Status,
        data.Duration,
        data.StartTime,
        data.EndTime,
        data.Estimatehours,
        data.Priority);
    return task;
}

function UITaskToLiElement(task) {
    var cssClass = GetStatusClassName(task.Status);
    var element = '<li class="Node ' + cssClass + '">' + MakeIdentityDiv(task, cssClass) + MakeContentDiv(task, cssClass) + '</li>';
    return element;
}

