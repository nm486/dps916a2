@ModelType A2MVCApplication.A2Models.EmailModel

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>EmailModel</legend>

        @Html.HiddenFor(Function(model) model.EmailId)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.RecordId, "Record")
        </div>
        <div class="editor-field">
            @Html.DropDownList("RecordId", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.RecordId)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Text)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Text)
            @Html.ValidationMessageFor(Function(model) model.Text)
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
