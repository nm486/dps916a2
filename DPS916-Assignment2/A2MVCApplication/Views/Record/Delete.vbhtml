@ModelType A2MVCApplication.A2Models.RecordModel

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this Record?</h3>
<fieldset>
    <legend>RecordModel</legend>
    <br />
    <div class="display-label">
        @Html.LabelFor(Function(model) model.UserName)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.UserName)
    </div>
    <br />
    <div class="display-label">
        @Html.LabelFor(Function(model) model.Notes)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Notes)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to Address Book", "Details", "AddressBook", New With {.id = Model.AddressBookId}, Nothing)
    </p>
End Using
