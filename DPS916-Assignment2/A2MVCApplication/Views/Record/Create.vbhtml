@ModelType A2MVCApplication.A2Models.RecordModel

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using Html.BeginForm()

    @<fieldset>
        <legend>RecordModel</legend>

        @Html.Hidden("AddressBookId", ViewData("id"))
        <div class="editor-label">
            @Html.LabelFor(Function(model) model.UserName, "UserName")
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.UserName)
            @Html.ValidationMessageFor(Function(model) model.UserName)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Notes)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Notes)
            @Html.ValidationMessageFor(Function(model) model.Notes)
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
