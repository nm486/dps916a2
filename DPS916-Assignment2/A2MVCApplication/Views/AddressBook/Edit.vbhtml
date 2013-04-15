@ModelType A2MVCApplication.A2Models.AddressBookModel

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>AddressBookModel</legend>

        @Html.HiddenFor(Function(model) model.AddressBookId)
        
        <div class="editor-label">
            @Html.LabelFor(Function(model) model.AddressBookName, "Address Book Name")
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.AddressBookName)
            @Html.ValidationMessageFor(Function(model) model.AddressBookName)
        </div>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
