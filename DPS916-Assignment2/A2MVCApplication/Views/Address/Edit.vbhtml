@ModelType A2MVCApplication.A2Models.AddressModel

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit Address for @ViewData("username")</h2>

@Using Html.BeginForm()

    @<fieldset>
        <legend>AddressModel</legend>
        @Html.Hidden("AddressId", Model.AddressId)
        @Html.Hidden("RecordId", Model.RecordId)
        <br />
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
