@ModelType A2MVCApplication.A2Models.CellPhoneNumberModel

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()

    @<fieldset>
        <legend>CellPhoneNumberModel</legend>

        @Html.HiddenFor(Function(model) model.CellPhoneId)
        @Html.HiddenFor(Function(model) model.RecordId)
      
        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Text)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Text)
            @Html.ValidationMessageFor(Function(model) model.Text)
        </div>
        <br /> All that is required are the numbers - no special characters needed.  Phone numbers are automatically formatted.
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to Record", "Edit", "Record", New With {.id = Model.RecordId}, Nothing)
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
