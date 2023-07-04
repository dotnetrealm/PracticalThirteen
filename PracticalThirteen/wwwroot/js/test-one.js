$(document).ready(() => {
    const noUserCheck = () => {
        if ($("#EmployeeTable tbody > tr").length == 0) {
            var data = "<tr id='NoUserFound'><td colspan='5' class='h4'><i class='fa fa-id-card'></i> Employee record not found</td></tr>";
            $("#EmployeeTable tbody").html(data);
        } else {
            $("#EmployeeTable tbody #NoUserFound").remove();
        }
    }

    //convert JSON date
    const parseJsonDate = (jsonDateString) => {
        return String(jsonDateString).split("T")[0];
    }

    const makeToast = (message) => {
        var url = 'Toast/Index?message=' + encodeURIComponent(message);
        $.get(url, (res) => {
            $("#ToastDisplay").html(res);
            $('.toast').toast('show');
        })
    }

    const createTableRow = (employee) => {
        return `<tr id="` + employee.id + `">
                    <th scope="row">`+ employee.id + `</th>
                                    <td>`+ employee.name + `</td>
                            <td>`+ parseJsonDate(employee.joiningDate) + `</td>
                    <td>`+ employee.age + `</td>
                    <td>
                        <div class="d-flex justify-content-center">
                            <button class="btn btn-sm viewEmployee"><i class="fa fa-eye"></i> View</button>
                            <button class="btn btn-sm editEmployee"><i class="fa fa-user-pen"></i> Edit</button>
                            <button class="btn btn-sm deleteEmployee"><i class="fa fa-trash"></i> Delete</button>
                        </div>
                    </td>
                </tr>`
    }

    const deleteEmployee = (ele) => {
        $(ele).on("click", (event) => {
            if (confirm('Are you sure you want to delete this?')) {
                var employeeId = event.target.closest("tr").id;
                var url = 'TestOne/Delete/' + employeeId;
                $.ajax({
                    url,
                    type: "post",
                    data: { id: employeeId },
                    success: (res) => {
                        if (res.result == "OK") {
                            $("#" + employeeId).remove();
                            $("#EmployeeForm").empty();
                            makeToast("Employee deleted successfully");
                            noUserCheck();
                        }
                    },
                })
            }
        })
    }

    const viewEmployee = (ele) => {
        $(ele).on("click", (event) => {
            var url = 'TestOne/EmployeeDetails/' + event.target.closest("tr").id;
            $("#EmployeeForm").load(url);
        })
    }

    const editEmpolyee = (ele) => {
        $(ele).on("click", (event) => {
            var url = 'TestOne/Edit/' + event.target.closest("tr").id;
            $("#EmployeeForm").load(url, () => {
                $("#EditEmployeeForm").on("submit", (e) => {
                    e.preventDefault();
                    $.ajax({
                        url,
                        type: "post",
                        data: $("#EditEmployeeForm").serialize(),
                        success: (res) => {
                            if (res.result == "OK") {
                                var row = createTableRow(res.data.employee);
                                $("#" + res.data.employee.id).remove();
                                $(e).parent("tr").remove();
                                $("#EmployeeTable tbody").append(row);
                                $("#EmployeeForm").empty();
                                makeToast("Employee updated successfully");
                            }
                            else {
                                $("#ValidationSummary").removeClass("d-none");
                                $("#ValidationSummary").text(res.message);
                                //Generate toast
                                makeToast(res.message);
                            }
                        },
                    })
                })
            });
        })
    }

    const resetEventListner = () => {
        Array.from($(".deleteEmployee")).forEach((e) => deleteEmployee(e));
        Array.from($(".viewEmployee")).forEach((e) => viewEmployee(e));
        Array.from($(".editEmployee")).forEach((e) => editEmpolyee(e));
    }

    const loadEmpoloyees = () => {
        $("#EmployeeData").load("TestOne/GetAllEmployees", () => {
            resetEventListner();
            makeToast("Employee loaded!");
        });
    }

    $("#TestOneActions #LoadEmployees").on("click", (emp) => {
        loadEmpoloyees();
    });

    loadEmpoloyees();

    $("#CreateEmployee").on("click", (e) => {
        $("#EmployeeForm").load("TestOne/Create", () => {
            $("#CreateEmployeeForm").on("submit", (e) => {
                e.preventDefault();
                $.ajax({
                    url: "TestOne/Create",
                    type: "post",
                    data: $("#CreateEmployeeForm").serialize(),
                    success: (res) => {
                        if (res.result == "OK") {
                            var row = createTableRow(res.data.employee);
                            $("#EmployeeTable tbody").append(row);
                            $("#EmployeeForm").empty();
                            makeToast("Employee Created successfully");
                            resetEventListner();
                            noUserCheck();
                        }
                        else {
                            $("#ValidationSummary").removeClass("d-none");
                            $("#ValidationSummary").text(res.message);
                            //Generate toast
                            makeToast(res.message);
                        }
                    },
                })
            });
        });
    });

})