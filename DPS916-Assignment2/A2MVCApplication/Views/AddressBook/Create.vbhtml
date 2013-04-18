@ModelType A2MVCApplication.A2Models.AddressBookModel

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create a New Address Book</h2>

@Using Html.BeginForm()

    @<fieldset>
        <legend>AddressBookModel</legend>
        <br /><br />
        @Html.LabelFor(Function(model) model.AddressBookName)
        @Html.EditorFor(Function(model) model.AddressBookName) @Html.ValidationMessageFor(Function(model) model.AddressBookName)
        <br />
        <span class="help-text">After you give your new address book a name and create it, you'll be able to add new records to it.</span>
        <br /><br />
        <p>
            <input type="submit" value="Create Address Book" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to Address Book List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
