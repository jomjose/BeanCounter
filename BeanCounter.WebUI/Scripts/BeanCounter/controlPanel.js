var controlPanel = function () {

    var controlPanelMethod = {};
    controlPanelMethod.categoryElement = null;

    controlPanelMethod.initialize = function () {
        controlPanelMethod.setSidebar();
        controlPanelMethod.setEvents();
    };

    controlPanelMethod.setSidebar = function () {
        $(".sidebar-menu li").removeClass("active");
        $("#licontrolPanel").addClass("active");
    };

    controlPanelMethod.chooseCategoryEvent = function () {

        if ($("#spnAddOrUpdate").hasClass("glyphicon-plus")) {
            controlPanelMethod.addNewCategory();
        }
        else {
            controlPanelMethod.updateCategory();
        }
    };



    controlPanelMethod.addNewCategory = function () {
        var category = {};
        category.ExpenseCategory = $("#txtCategory").val().trim();
        common.ajax("AddNewCategory", JSON.stringify(category), controlPanelMethod.buildCategoryTable);
    };

    controlPanelMethod.updateCategory = function (that) {
        var category = {};
        category.ExpenseCategory = $("#txtCategory").val().trim();
        category.ExpenseCategoryId = $(controlPanelMethod.categoryElement).data("categoryid");
        common.ajax("UpdateCategory", JSON.stringify(category), controlPanelMethod.afterCategoryUpdation);
    };

    controlPanelMethod.deleteCategory = function (that) {

        var isDelete = confirm("Do you want to remove this category ");
        if (isDelete) {
            controlPanelMethod.categoryElement = that;
            var category = {};
            category.ExpenseCategoryId = $(that).data("categoryid");
            common.ajax("DeleteCategory", JSON.stringify(id), controlPanelMethod.afterCategoryDelete);
        }
    };




    controlPanelMethod.buildCategoryTable = function (data) {
        if (data != null) {
            if (data.ExpenseCategoryId != -1) {
                $("#tmpltCategory").tmpl(data).appendTo("#categoryContainer");
            }
            else {
                alert("Category exists");
            }
            controlPanelMethod.resetCategoryForm();
        }
        else {
            alert("Something went wrong. Please try again.");
        }
    };

    controlPanelMethod.afterCategoryDelete = function (data) {
        if (data) {
            $(controlPanelMethod.categoryElement).remove();
            controlPanelMethod.categoryElement = null;
        }
        else {
            alert("Something went wrong. please try again.");
        }
    };

    controlPanelMethod.afterCategoryUpdation = function (data) {

        if (data === 1) {
            $(controlPanelMethod.categoryElement).closest('tr').find("td:eq(1)").html($("#txtCategory").val().trim());
            $(controlPanelMethod.categoryElement).closest('tr').find(".btnUpdateCategory").data("category", $("#txtCategory").val().trim());;
            controlPanelMethod.resetCategoryForm();
        }
        else if (data === 0) {
            alert("Category exists. Updation ignored");
        }
        else {
            alert("Something went wrong. Please try again.")
        }
    };



    controlPanelMethod.prepareForCategoryUpdate = function (that) {

        $("#spnAddOrUpdate").removeClass("glyphicon-plus").addClass("glyphicon-refresh");
        $("#btnCancelCategory").removeClass("hide");
        $("#txtCategory").val($(that).data("category"));
        controlPanelMethod.categoryElement = that;

    };

    controlPanelMethod.resetCategoryForm = function () {
        $("#txtCategory").val("");
        $("#spnAddOrUpdate").removeClass("glyphicon-refresh").addClass("glyphicon-plus");
        $("#btnCancelCategory").addClass("hide");
        controlPanelMethod.categoryElement = null;
    };


    controlPanelMethod.setEvents = function () {

        $("#btnAddOrUpdateCategory").unbind().click(function () {
            controlPanelMethod.chooseCategoryEvent();
        });

        $("#btnCancelCategory").unbind().click(function () {
            controlPanelMethod.resetCategoryForm();
        });

        $("body").on('click', '.btnUpdateCategory', function () {
            controlPanelMethod.prepareForCategoryUpdate(this);
        });

        $("body").on('click', '.btnDeleteCategoryr', function () {
            controlPanelMethod.deleteCategory(this);
        });
    };

    return controlPanelMethod;
}();

$(function () {
    controlPanel.initialize();
})