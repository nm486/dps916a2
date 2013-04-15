@ModelType A2MVCApplication.A2Models.AddressModel

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this Address?</h3>
<fieldset>
    <legend>AddressModel</legend>
    <br />
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Text)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to Record", "Edit", "Record", New With {.id = Model.RecordId}, Nothing)
    </p>
End Using
