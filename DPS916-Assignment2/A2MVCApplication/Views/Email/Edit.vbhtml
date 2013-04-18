@ModelType A2MVCApplication.A2Models.EmailModel

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()

    @<fieldset>
        <legend>EmailModel</legend>

        @Html.HiddenFor(Function(model) model.EmailId)
        @Html.HiddenFor(Function(model) model.RecordId)

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
    @Html.ActionLink("Back to Record", "Edit", "Record", New With {.id = Model.RecordId}, Nothing)
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
